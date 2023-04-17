using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class iconObject
{
    public Sprite icon;
    public GameObject GObject;
}


[CreateAssetMenu(fileName = "iconObject", menuName = "Scriptable Objects/Icon Object Pair", order = 1)]
public class iconObjectScriptableObject : ScriptableObject
{

    public List<iconObject> IconObjectPairList;

}
