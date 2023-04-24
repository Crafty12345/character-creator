using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ColourSelectManager : MonoBehaviour
{

    public void onClick()
    {
        GameObject sender = this.gameObject;
        GameObject gameManagerManager = GameObject.FindGameObjectWithTag("GameManager");
        GameObject colourIcon = FindChildByTag(this.gameObject,"ColourIcon");
        Color new_colour = colourIcon.GetComponent<Image>().color;
        GameStateManager gameManager = gameManagerManager.GetComponent<GameStateManager>();
        CharacterStateManager characterManager = gameManager.characterObject.GetComponent<CharacterStateManager>();

        switch(sender.tag)
        {
            case "SkinColourButton":
                foreach(GameObject part in characterManager.MaterialMap.Skin)
                {
                    part.GetComponent<Renderer>().material.color = new_colour;
                }
                break;
        }
        refreshBoxIcons(sender, new_colour);
    }

    GameObject FindChildByTag(GameObject parent, string tag)
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

    public void refreshBoxIcons(GameObject sender,Color new_colour)
    {
        GameObject[] all_boxes = GameObject.FindGameObjectsWithTag(sender.tag);
        boxIconManager iconManager;
        foreach(GameObject box in all_boxes)
        {
            iconManager = box.GetComponent<boxIconManager>();
            if (showBasicColourSelector.checkColourSimilarity(FindChildByTag(box,"ColourIcon").GetComponent<Image>().color, new_colour, 0.05f)){
                iconManager.Selected = true;

            }
            else
            {
                iconManager.Selected = false;
            }
            iconManager.refresh();
        }

    }

}
