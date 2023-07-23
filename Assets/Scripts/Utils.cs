using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static GameObject FindChildByTag(GameObject parent, string tag)
    {
        foreach (Transform child_object in parent.transform)
        {
            if (child_object.tag == tag)
            {
                return child_object.gameObject;
            }
        }
        return null;
    }

    public static string CapitaliseFirstLetter(string str)
    {
        if (string.IsNullOrEmpty(str)) {
            Debug.LogWarning("An empty string was parsed to Utils.CapitaliseFirstLetter()");
            return str;
        }
        else
        {
            if (str.Length == 1)
            {
                return str.ToUpper();
            }
            else
            {
                return char.ToUpper(str[0]) + str.Substring(1);
            }
        }
    }

    public static bool isStartScreenExists(Transform transform)
    {
        foreach (Transform p in transform.parent.parent.GetComponentsInChildren<Transform>())
        {
            if (p.gameObject.CompareTag("StartScreen"))
            {
                return true;
            }
        }
        return false;
    }

}
