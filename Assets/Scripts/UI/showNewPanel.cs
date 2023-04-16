using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class showNewPanel : MonoBehaviour
{
    [System.Serializable]
    public class requiredData
    {
        public GameObject sender;
        public colourGroupScriptableObjectManager colourGroup;
    }

    public requiredData data;

    public void showPanel()
    {
 GameObject sender = data.sender;
 colourGroupScriptableObjectManager colourGroup = data.colourGroup;
 foreach (Color colour in colourGroup.Colours)
        {
 Console.WriteLine(colour);
   }
    }


}
