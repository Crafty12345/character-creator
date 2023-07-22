using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class HexadecimalColourManager : MonoBehaviour
{

    TMP_InputField input;
    public Slider slider;
    public GameObject preview;


    private void Awake()
    {
        input = gameObject.GetComponent<TMP_InputField>();
    }

    public void OnTextEnter()
    {
        string text = input.text;
        Color new_col;
        ColorUtility.TryParseHtmlString(("#" + text),out new_col);
        preview.GetComponent<ColourPreviewManager>().update_colour_hex(new_col);
        preview.GetComponent<ColourPreviewManager>().raw_colour = new_col;
        slider.value = new_col.grayscale;

    }

}
