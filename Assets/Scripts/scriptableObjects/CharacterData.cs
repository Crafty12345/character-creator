using UnityEditor;
using UnityEngine;


[CreateAssetMenu(fileName = "characterData", menuName = "Scriptable Objects/Character Data", order = 1)]
public class CharacterData : ScriptableObject
{
    public string Name;
    public float Height;
    public float Size;
}
