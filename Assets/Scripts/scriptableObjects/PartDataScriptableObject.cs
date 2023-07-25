using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class PartDataData
{
    public Sprite partIcon;
    public GameObject GObject;
    public Vector3 partOffset;
}


[CreateAssetMenu(fileName = "partDataList", menuName = "Scriptable Objects/Part Data List", order = 1)]
public class PartDataScriptableObject : ScriptableObject
{
    public string partType;
    public List<PartDataData> PartDataList;

    public List<Sprite> GetSprites()
    {
        List<Sprite> list = new List<Sprite>();

        foreach(PartDataData part in PartDataList)
        {
            list.Add(part.partIcon);
        }
        return list;
    }

}
