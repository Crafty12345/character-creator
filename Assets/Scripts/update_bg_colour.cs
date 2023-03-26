using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class update_bg_colour : MonoBehaviour
{
    public Scrollbar redScrollbar;
    public Scrollbar greenScrollbar;
    public Scrollbar blueScrollbar;
    public Material bgMaterial;
    public GameObject background;

    void Start(){
        redScrollbar.onValueChanged.AddListener((float val)=>updateColour());
        blueScrollbar.onValueChanged.AddListener((float val)=>updateColour());
        greenScrollbar.onValueChanged.AddListener((float val)=>updateColour());
    }

    public void updateColour(){
        Color new_colour = new Color((redScrollbar.value),(greenScrollbar.value),(blueScrollbar.value),1);
        Debug.Log(new_colour);
        background.GetComponent<Renderer>().material.color = new_colour;
    }

};
