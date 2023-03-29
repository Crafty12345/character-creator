using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class mouseIconManager : MonoBehaviour
{

    public Texture2D handIcon;
    public Texture2D pointerIcon;

    public void setToHand()
    {
        Cursor.SetCursor(handIcon,new Vector2(8,0),CursorMode.Auto);
    }

    public void setToPointer()
    {
        Cursor.SetCursor(pointerIcon, new Vector2(8, 0), CursorMode.Auto);
    }

}
