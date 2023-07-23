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
        GameObject colourIcon = Utils.FindChildByTag(this.gameObject,"ColourIcon");
        Color new_colour = colourIcon.GetComponent<Image>().color;
        GameStateManager gameManager = gameManagerManager.GetComponent<GameStateManager>();
        CharacterStateManager characterManager = gameManager.characterObject.GetComponent<CharacterStateManager>();

        switch(sender.tag)
        {
            case "SkinColourButton":
                foreach(GameObject part in characterManager.materialMap.Skin)
                {
                    part.GetComponent<Renderer>().material.color = new_colour;
                }
                break;
            case "OutfitColourButton":
                foreach (GameObject part in characterManager.materialMap.Outfit)
                {
                    part.GetComponent<Renderer>().material.color = new_colour;
                }
                break;
        }
        refreshBoxIcons(sender, new_colour);
    }

    public void refreshBoxIcons(GameObject sender,Color new_colour)
    {
        GameObject[] all_boxes = GameObject.FindGameObjectsWithTag(sender.tag);
        boxIconManager iconManager;
        foreach(GameObject box in all_boxes)
        {
            iconManager = box.GetComponent<boxIconManager>();
            if (showBasicColourSelector.checkColourSimilarity(Utils.FindChildByTag(box,"ColourIcon").GetComponent<Image>().color, new_colour, 0.05f)){
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
