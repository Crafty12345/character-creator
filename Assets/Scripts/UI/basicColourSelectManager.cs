using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicColourSelectManager : MonoBehaviour
{

    public string partType;
    public Color old_colour;

    private void Start()
    {

        try
        {
            partType = transform.parent.GetComponent<BasicColourSelectManager>().partType;
        }
        catch (System.Exception e)
        {
            if (e.GetType().ToString() == "NullReferenceException")
            {
                partType = transform.parent.GetComponent<AdvancedColourSelectManager>().partType;
            }
        }

        GameObject player = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameStateManager>().characterObject;
        switch (partType)
        {
            case "skin":
                {

                    old_colour = player.GetComponent<CharacterStateManager>().materialMap.Skin[0].GetComponent<Renderer>().material.color;
                    break;
                }
            case "outfit":
                {
                    old_colour = player.GetComponent<CharacterStateManager>().materialMap.Outfit[0].GetComponent<Renderer>().material.color;
                    break;
                }
        }

    }

}
