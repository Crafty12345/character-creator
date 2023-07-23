using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class _PartData
{
    public Sprite partIcon;
    public GameObject GObject;
    public Vector3 partOffset;
}


[CreateAssetMenu(fileName = "partDataList", menuName = "Scriptable Objects/Part Data List", order = 1)]
public class PartDataScriptableObject : ScriptableObject
{
    public string partType;
    public List<_PartData> PartDataList;

}
