using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct MaterialMap
{
    public List<GameObject> Eye;
    public List<GameObject> Hair;
    public List<GameObject> Eyebrow;
    public List<GameObject> Skin;
    public List<GameObject> Outfit;
}

[System.Serializable]
public struct PartObject
{
    public GameObject HairObject;
    public GameObject HeadObject;
    public GameObject LeftEyebrowObject;
    public GameObject RightEyebrowObject;
    public GameObject MouthObject;
    public GameObject LeftEyeObject;
    public GameObject RightEyeObject;
    public GameObject NoseObject;

}


public class CharacterStateManager : MonoBehaviour
{
    public string characterID;
    public MaterialMap materialMap;
    public PartObject partObject;

    public Material hairMaterial;
    public Material skinMaterial;
    public Material outfitMaterial;
    public Material eyebrowMaterial;
    public Material eyeMaterial;
}
