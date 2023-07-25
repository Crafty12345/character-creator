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

    
    void SetCharacterMaterials(GameObject new_character, materialJSONData[] default_materials)
    {
        foreach (materialJSONData material in default_materials)
        {
            Material part_material = material.toMaterial();
            switch (material.name)
            {
                case "default_hair_colour":
                    new_character.GetComponent<CharacterStateManager>().hairMaterial = part_material;
                    foreach (GameObject part in new_character.GetComponent<CharacterStateManager>().materialMap.Hair)
                    {
                        part.GetComponent<MeshRenderer>().material = new_character.GetComponent<CharacterStateManager>().hairMaterial;
                    }
                    break;
                case "default_skin_colour":
                    new_character.GetComponent<CharacterStateManager>().skinMaterial = part_material;
                    foreach (GameObject part in new_character.GetComponent<CharacterStateManager>().materialMap.Skin)
                    {
                        part.GetComponent<MeshRenderer>().material = new_character.GetComponent<CharacterStateManager>().skinMaterial;
                    }
                    break;
                case "default_outfit_colour":
                    new_character.GetComponent<CharacterStateManager>().outfitMaterial = part_material;
                    foreach (GameObject part in new_character.GetComponent<CharacterStateManager>().materialMap.Outfit)
                    {
                        part.GetComponent<MeshRenderer>().material = new_character.GetComponent<CharacterStateManager>().outfitMaterial;
                    }
                    break;
                case "default_eye_colour":
                    new_character.GetComponent<CharacterStateManager>().eyeMaterial = part_material;
                    foreach (GameObject part in new_character.GetComponent<CharacterStateManager>().materialMap.Eye)
                    {
                        part.GetComponent<MeshRenderer>().material = new_character.GetComponent<CharacterStateManager>().eyeMaterial;
                    }
                    break;
                case "default_eyebrow_colour":
                    new_character.GetComponent<CharacterStateManager>().eyebrowMaterial = part_material;
                    foreach (GameObject part in new_character.GetComponent<CharacterStateManager>().materialMap.Eyebrow)
                    {
                        part.GetComponent<MeshRenderer>().material = new_character.GetComponent<CharacterStateManager>().eyebrowMaterial;
                    }
                    break;
            }

        }
    }

    void Awake()
    {
        string streaming_assets_path = Application.streamingAssetsPath;
        string character_data_path = streaming_assets_path + "/CharacterData";
        if (!Directory.Exists(character_data_path)){
            Directory.CreateDirectory(character_data_path);
        }
        character_data_path += "/";
        TimeSpan t = DateTime.Now - new DateTime(1970, 1, 1);
        string dirName = Convert.ToString((int)t.TotalSeconds);
        string new_dir_path = character_data_path + dirName;
        Directory.CreateDirectory(new_dir_path);
        string player_materials_dir = Directory.CreateDirectory(new_dir_path+"/Materials").ToString();
        UnityEngine.Object[] default_materials_temp = Resources.LoadAll("Materials/default/ScriptableObjects", typeof(materialJSONData));
        materialJSONData[] default_materials = new materialJSONData[default_materials_temp.Length];
        for (int i = 0; i < default_materials_temp.Length; i++)
        {
            default_materials[i] = (materialJSONData)default_materials_temp[i];
        }
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        foreach (materialJSONData material in default_materials)
        {

            string new_materials_path = player_materials_dir + "/" +  material.name.Replace("default_", "") + ".json";
            FileManager.WriteBinary(material.toJson(),new_materials_path);

        }
        AssetDatabase.Refresh();

        GameObject characterPrefab = Resources.Load<GameObject>($"Prefabs/Character/default_character/{selected_character_id}");
        GameObject new_character = GameObject.Instantiate(characterPrefab);
        new_character.GetComponent<CharacterStateManager>().characterID = dirName;

        SetCharacterMaterials(new_character, default_materials);

        GameStateManager gameState = this.gameObject.GetComponent<GameStateManager>();
        gameState.characterID = dirName;
        gameState.characterObject = new_character;
        
    }

}
