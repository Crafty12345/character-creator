using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class boxIconManager : MonoBehaviour
{
    public bool Selected;


    public void setToUnderline(GameObject gObject)
    {
        if (Selected)
        {
            gObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/textures/misc/empty_box/selected/selected_underline");
        }
        else {
            gObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/textures/misc/empty_box/unselected/unselected_with_underline");
        }
    }

    public void setToNoUnderline(GameObject gObject)
    {
        if (Selected) {
            gObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/textures/misc/empty_box/selected/selected");
        }
        else
        {
            gObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/textures/misc/empty_box/unselected/unselected");
        }
        
    }

    public void refresh()
    {
        if (Selected)
        {
            this.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/textures/misc/empty_box/selected/selected");
        }
        else
        {
            this.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/textures/misc/empty_box/unselected/unselected");
        }
    }

}
