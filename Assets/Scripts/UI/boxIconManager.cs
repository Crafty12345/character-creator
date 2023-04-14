using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class boxIconManager : MonoBehaviour
{
    public Sprite box_no_underline;
    public Sprite box_underline;


    public void setToUnderline(GameObject gObject)
    {
        gObject.GetComponent<Image>().sprite = box_underline;
    }

    public void setToNoUnderline(GameObject gObject)
    {
        gObject.GetComponent<Image>().sprite = box_no_underline;
    }

}
