using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class mouseIconManager : MonoBehaviour
{
    
    Texture2D handIcon;
    Texture2D pointerIcon;
    Texture2D iBeamIcon;

    private void Awake()
    {
        handIcon = Resources.Load<Texture2D>("UI/textures/cursors/_aero_link");
        pointerIcon = Resources.Load<Texture2D>("UI/textures/cursors/_aero_arrow");
        iBeamIcon = Resources.Load<Texture2D>("UI/textures/cursors/_aero_iBeam");

    }

    public void setToHand()
    {
        if(gameObject.GetComponent<Button>() != null) {
            if (gameObject.GetComponent<Button>().interactable == true){
                Cursor.SetCursor(handIcon, new Vector2(8, 0), CursorMode.Auto);
            }
        }
    }

    public void setToPointer()
    {
        if (gameObject.GetComponent<Button>() != null)
        {
            if (gameObject.GetComponent<Button>().interactable == true)
            {
                Cursor.SetCursor(pointerIcon, new Vector2(8, 0), CursorMode.Auto);
            }

        }
    }

    public void setToiBeam()
    {
        Cursor.SetCursor(iBeamIcon, new Vector2(8, 0), CursorMode.Auto);
    }

}
