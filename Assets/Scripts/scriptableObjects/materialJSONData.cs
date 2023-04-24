using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName = "json_material", menuName = "Scriptable Objects/ Material JSON Data")]
public class materialJSONData : ScriptableObject
{

    public Color colour;
    public Shader shader;
    [SerializeField]
    [Tooltip(@"
    0: Opaque
    1: Cutout
    2: Fade
    3: Transparent")]
    public float renderMode;
    public float roughness;


    public string toJson()
    {
        return JsonUtility.ToJson(this, true);
    }

    public void fromMaterial(Material mat)
    {
        this.colour = mat.color;
        this.shader = mat.shader;
        this.renderMode = mat.GetFloat("_Mode");
        this.roughness = mat.GetFloat("_Glossiness");
    }

    public Material toMaterial()
    {
        Material new_material = new Material(this.shader);
        new_material.color = this.colour;
        new_material.shader = this.shader;
        new_material.SetFloat("_Mode",this.renderMode);
        new_material.SetFloat("_Glossiness", this.roughness);
        return new_material;
    }

}
