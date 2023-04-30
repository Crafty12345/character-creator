using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TextInputValidator : MonoBehaviour
{
    public int charLimit;
    public List<char> allowed_chars = new List<char>();
    // Start is called before the first frame update
    void Start()
    {
        TMP_InputField text_box = gameObject.GetComponent<TMP_InputField>();
        text_box.characterLimit = charLimit;
    }

    public void ValidateInput()
    {
        char[] stringChars = gameObject.GetComponent<TMP_InputField>().text.ToCharArray();
        List<char> valid_chars = new List<char>();
        foreach (char c in stringChars)
        {
            if (allowed_chars.Contains(c))
            {
                valid_chars.Add(c);
            }
        }
        gameObject.GetComponent<TMP_InputField>().text = new string(valid_chars.ToArray());

    }

}
