using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName="colourGroup",menuName="Scriptable Objects/Colour Group",order=1)]
public class colourGroupScriptableObjectManager : ScriptableObject
{
    public List<Color> Colours;
}
