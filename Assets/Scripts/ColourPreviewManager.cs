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
    public string materialType;

    private void Awake()
    {
        brightness = 0.5f;
        active_colour = brightnessManager.calculateBrightness(raw_colour, brightness, new Color(0, 0, 0), new Color(1, 1, 1));
        active_colour.a = 1;
        materialType = gameObject.transform.parent.parent.GetComponent<BasicColourSelectManager>().materialType;
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
        switch (materialType)
        {
            case "skin":
                player.GetComponent<CharacterStateManager>().skinMaterial.color = active_colour;
                break;

            case "outfit":
                player.GetComponent<CharacterStateManager>().outfitMaterial.color = active_colour;
                break;
            case "hair":
                player.GetComponent<CharacterStateManager>().hairMaterial.color = active_colour;
                break;
        }

    }
}
