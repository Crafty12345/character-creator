using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEditor;

public class Startup : MonoBehaviour
{

    void Awake()
    {
        TimeSpan t = DateTime.Now - new DateTime(1970, 1, 1);
        string dirName = Convert.ToString((int)t.TotalSeconds);
        string new_dir_path = "Assets/Resources/PlayerData/" + dirName;
        AssetDatabase.CreateFolder("Assets/Resources/PlayerData", dirName);
        string player_materials_dir = AssetDatabase.GUIDToAssetPath(AssetDatabase.CreateFolder(new_dir_path, "Materials"));

        string[] default_materials = AssetDatabase.FindAssets("", new[] { "Assets/Resources/Materials/default" });
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        foreach (string material in default_materials)
        {
            string new_materials_dir = player_materials_dir;

            string material_stripped = AssetDatabase.GUIDToAssetPath(material);
            Debug.Log(material_stripped);
            var mat = AssetDatabase.LoadAssetAtPath<Material>(material_stripped);
            var clonedMat = UnityEngine.Object.Instantiate(mat);
            new_materials_dir += "/" + ((Path.GetFileName(material_stripped))).Replace("default_","");
            AssetDatabase.CreateAsset(clonedMat, new_materials_dir);

        }
        

    }

}
