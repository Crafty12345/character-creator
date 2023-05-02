using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class HexadecimalColourManager : MonoBehaviour
{

    TMP_InputField input;


    private void Awake()
    {
        input = gameObject.GetComponent<TMP_InputField>();
    }

    public void OnTextEnter()
    {
        string text = input.text;
    }

}
