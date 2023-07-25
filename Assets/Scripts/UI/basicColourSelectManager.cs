using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicColourSelectManager : MonoBehaviour
{

    public string materialType;
    public Color old_colour;

    private void Start()
    {

        try
        {
            materialType = transform.parent.GetComponent<BasicColourSelectManager>().materialType;
        }
        catch (System.Exception e)
        {
            if (e.GetType().ToString() == "NullReferenceException")
            {
                materialType = transform.parent.GetComponent<AdvancedColourSelectManager>().materialType;
            }
        }

        GameObject player = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameStateManager>().characterObject;
        CharacterStateManager characterState = player.GetComponent<CharacterStateManager>();
        switch (materialType)
        {
            case "skin":
                {

                    old_colour = characterState.skinMaterial.color;
                    break;
                }
            case "outfit":
                {
                    old_colour = characterState.outfitMaterial.color;
                    break;
                }
            case "hair":
                old_colour = characterState.hairMaterial.color;
                break;

        }

    }

}
