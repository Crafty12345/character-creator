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

public class CharacterStateManager : MonoBehaviour
{
    public string characterID;
    public MaterialMap materialMap;
}
