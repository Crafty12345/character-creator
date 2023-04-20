using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class boxIconManager : MonoBehaviour
{
    private Sprite box_no_underline;
    private Sprite box_underline;
    private Sprite box_selected_no_underline;
    private Sprite box_selected_underline;
    public bool Selected;


    public void setToUnderline(GameObject gObject)
    {
        if (Selected)
        {
            box_underline = Resources.Load<Sprite>("UI/textures/misc/empty_box/selected/selected_underline");
        }
        else {
            box_underline = Resources.Load<Sprite>("UI/textures/misc/empty_box/unselected/unselected_with_underline");
        }
        gObject.GetComponent<Image>().sprite = box_underline;
    }

    public void setToNoUnderline(GameObject gObject)
    {
        if (Selected) {
            box_no_underline = Resources.Load<Sprite>("UI/textures/misc/empty_box/selected/selected");
        }
        else
        {
            box_no_underline = Resources.Load<Sprite>("UI/textures/misc/empty_box/unselected/unselected");
        }
        
        gObject.GetComponent<Image>().sprite = box_no_underline;
    }

}
