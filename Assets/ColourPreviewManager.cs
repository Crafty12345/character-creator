using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourPreviewManager : MonoBehaviour
{
    public Color raw_colour;
    public float brightness;
    public brightnessSliderManager brightnessManager;

    public void update_preview()
    {
        brightness = 0.5f;
        Color active_colour = brightnessManager.calculateBrightness(raw_colour, brightness, new Color(0, 0, 0), new Color(1, 1, 1));
        active_colour.a = 1;
        gameObject.GetComponent<Image>().color = active_colour;
    }
}
