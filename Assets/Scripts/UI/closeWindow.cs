using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class closeWindow : MonoBehaviour
{
    public Color old_colour;
    void Start()
    {
        string partType = "";
        try
        {
            partType = transform.parent.GetComponent<basicColourSelectManager>().partType;
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

    bool isStartScreenExists()
    {
        foreach (Transform p in gameObject.transform.parent.parent.GetComponentsInChildren<Transform>())
        {
            if (p.gameObject.CompareTag("StartScreen"))
            {
                return true;
            }
        }
        return false;
    }

    public void onClick()
    {
       
        if(isStartScreenExists())
        {

            GameObject startScreen = GameObject.FindWithTag("StartScreen");
            Component[] dis_buts = startScreen.transform.GetComponentsInChildren<Button>();
            foreach (Button button in dis_buts)
            {

                button.interactable = true;

            }

        }
        GameObject.Destroy(gameObject.transform.parent.gameObject);
    }

}