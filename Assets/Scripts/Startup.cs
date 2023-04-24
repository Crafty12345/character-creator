using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;


public class Startup : MonoBehaviour
{

    public string selected_character_id;

    void Awake()
    {
        TimeSpan t = DateTime.Now - new DateTime(1970, 1, 1);
        string dirName = Convert.ToString((int)t.TotalSeconds);
        string new_dir_path = "Assets/CharacterData/" + dirName;
        AssetDatabase.CreateFolder("Assets/CharacterData", dirName);
        var player_materials_dir = Directory.CreateDirectory(new_dir_path+"/Materials");
        string[] default_materials = Directory.GetFiles("Assets/Resources/Materials/default/ScriptableObjects","*.asset");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        foreach (string material in default_materials)
        {
            string new_materials_dir = $"Assets/CharacterData/{dirName}/materials";
            string material_path_relative = Path.Combine("Materials/default/ScriptableObjects", Path.GetFileNameWithoutExtension(material));
            new_materials_dir += "/" + ((Path.GetFileName(material_path_relative))).Replace("default_","") + ".json";
            materialJSONData materialJSON = Resources.Load<materialJSONData>(material_path_relative);
            FileManager.WriteBinary(materialJSON.toJson(),new_materials_dir);

        }
        AssetDatabase.Refresh();

        GameObject characterPrefab = Resources.Load<GameObject>($"Prefabs/Character/default_character/{selected_character_id}");
        GameObject new_character = GameObject.Instantiate(characterPrefab);
        new_character.GetComponent<CharacterStateManager>().characterID = dirName;

        GameStateManager gameState = this.gameObject.GetComponent<GameStateManager>();
        gameState.characterID = dirName;
        gameState.characterObject = new_character;
        

    }

}
