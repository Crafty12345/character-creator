using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ColourPreviewManager : MonoBehaviour
{
    public Color raw_colour;
    public float brightness;
    public brightnessSliderManager brightnessManager;
    public Color active_colour;
    public string partType;

    private void Awake()
    {
        brightness = 0.5f;
        active_colour = brightnessManager.calculateBrightness(raw_colour, brightness, new Color(0, 0, 0), new Color(1, 1, 1));
        active_colour.a = 1;
        partType = gameObject.transform.parent.parent.GetComponent<BasicColourSelectManager>().partType;
    }

    public void update_preview()
    {
        active_colour = brightnessManager.calculateBrightness(raw_colour, brightness, new Color(0, 0, 0), new Color(1, 1, 1));
        gameObject.GetComponent<Image>().color = active_colour;
        updatePartColour();
    }

    public void update_colour_hex(Color colour)
    {
        active_colour = colour;
        gameObject.GetComponent<Image>().color = active_colour;
        updatePartColour();
    }

    public void updatePartColour()
    {
        GameObject player = GameObject.FindWithTag("GameManager").GetComponent<GameStateManager>().characterObject;
        MaterialMap matMap = player.GetComponent<CharacterStateManager>().materialMap;
        switch (partType)
        {
            case "skin":
                foreach (GameObject matObject in matMap.Skin)
                {
                    matObject.GetComponent<Renderer>().material.color = active_colour;
                }
                break;

            case "outfit":
                foreach (GameObject matObject in matMap.Outfit)
                {
                    matObject.GetComponent<Material>().color = active_colour;
                }
                break;
        }

    }
}
