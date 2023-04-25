using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextInputValidator : MonoBehaviour
{
    public int charLimit;
    public List<char> allowed_chars = new List<char>();
    // Start is called before the first frame update
    void Start()
    {
        InputField text_box = gameObject.GetComponent<InputField>();
        text_box.characterLimit = charLimit;
    }

    public void ValidateInput()
    {
        char[] stringChars = gameObject.GetComponent<InputField>().text.ToCharArray();
        List<char> valid_chars = new List<char>();
        foreach (char c in stringChars)
        {
            if (allowed_chars.Contains(c))
            {
                valid_chars.Add(c);
            }
        }
        gameObject.GetComponent<InputField>().text = new string(valid_chars.ToArray());

    }

}
