using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class brightnessSliderManager : MonoBehaviour
{
    public GameObject sliderIcon;
    public float scale_factor;
    public float lerp_time;

    IEnumerator SmoothScale(Vector3 original_scale, Vector3 new_scale,RectTransform rect)
    {
        float current_time = 0.0f;
        do
        {
            rect.localScale = Vector3.Lerp(original_scale, new_scale, current_time / lerp_time);
            current_time += Time.deltaTime;
            yield return null;
        } while (current_time <= lerp_time);
    }

    public Color calculateBrightness(Color base_colour, float brightness, Color min_colour, Color max_colour)
    {
        float new_red;
        float new_green;
        float new_blue;

        new_red = Math.Min(base_colour.r * brightness, max_colour.r);
        new_red = Math.Max(base_colour.r * brightness, min_colour.r);

        new_green = Math.Min(base_colour.g * brightness, max_colour.g);
        new_green = Math.Max(base_colour.g * brightness, min_colour.g);

        new_blue = Math.Min(base_colour.b * brightness, max_colour.b);
        new_blue = Math.Max(base_colour.b * brightness, min_colour.b);

        return new Color(new_red, new_green, new_blue,base_colour.a);
    }

    public void onValueChanged()
    {   
        Color default_colour_pressed = new Color(0.3806f, 0.5020f, 0.5566f, 0.9372f);
        Color min_pressed_colour = new Color(0, 0, 0);
        Color max_pressed_colour = new Color(1, 1, 1);

        Color default_colour_normal = new Color(0.3906f, 0.512f, 0.5666f, 0.9372f);
        Color min_normal_colour = new Color(0.1f, 0.1f, 0.1f);
        Color max_normal_colour = new Color(1, 1,1);

        Slider slider = this.gameObject.GetComponent<Slider>();
        float new_value = slider.value;
        Color new_slider_pressed_colour = calculateBrightness(default_colour_pressed, new_value,min_pressed_colour,max_pressed_colour);
        Color new_slider_normal_colour = calculateBrightness(new Color(default_colour_normal.r,default_colour_normal.g,default_colour_normal.b), new_value, min_normal_colour, max_normal_colour);
        ColorBlock slider_colours = slider.colors;
        slider_colours.pressedColor = new_slider_pressed_colour;
        slider_colours.normalColor = new_slider_normal_colour;
        slider_colours.selectedColor = new_slider_normal_colour;
        slider.colors = slider_colours;


    }

    public void setScale(bool is_selected)
    {
        if(is_selected)
        {
            StartCoroutine(SmoothScale(new Vector3(1,1,1),new Vector3(scale_factor,scale_factor,1), sliderIcon.GetComponent<RectTransform>()));
        }
        else
        {

            StartCoroutine(SmoothScale(new Vector3(scale_factor, scale_factor, scale_factor),new Vector3(1,1,1), sliderIcon.GetComponent<RectTransform>()));
        }
    }


}
