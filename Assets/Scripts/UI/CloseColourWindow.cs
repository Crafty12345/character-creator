using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseColourWindow: MonoBehaviour
{
    public Color old_colour;

    private GameObject sender;
    private GameObject gameManagerManager;
    public string materialType;
    private GameStateManager gameManager;
    private CharacterStateManager characterManager;

    void Start()
    {

        if(transform.parent.gameObject.TryGetComponent<BasicColourSelectManager>(out BasicColourSelectManager colSelect))
        {
            old_colour = colSelect.old_colour;
            materialType = colSelect.materialType;
        }
        else if (transform.parent.gameObject.TryGetComponent<AdvancedColourSelectManager>(out AdvancedColourSelectManager advColSelect))
        {
            old_colour = advColSelect.old_colour;
            materialType = advColSelect.materialType;
        }

        sender = this.gameObject;
        gameManagerManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = gameManagerManager.GetComponent<GameStateManager>();
        characterManager = gameManager.characterObject.GetComponent<CharacterStateManager>();
    }



    public void onClick()
    {
       
        if(Utils.isStartScreenExists(gameObject.transform))
        {

            GameObject startScreen = GameObject.FindWithTag("StartScreen");
            Component[] dis_buts = startScreen.transform.GetComponentsInChildren<Button>();
            foreach (Button button in dis_buts)
            {

                button.interactable = true;

            }

        }

        switch (materialType)
        {
            case "skin":
                foreach (GameObject part in characterManager.materialMap.Skin)
                {
                    part.GetComponent<Renderer>().material.color = old_colour;
                }
                break;
        }

        GameObject.Destroy(gameObject.transform.parent.gameObject);
    }

}