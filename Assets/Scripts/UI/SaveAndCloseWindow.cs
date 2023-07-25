using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveAndCloseWindow : MonoBehaviour
{

    GameObject gameManager;
    string materialType;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        if(transform.parent.gameObject.TryGetComponent<BasicColourSelectManager>(out BasicColourSelectManager colSelectManager))
        {
           materialType = colSelectManager.materialType;
        }
        else if (transform.parent.gameObject.TryGetComponent<AdvancedColourSelectManager>(out AdvancedColourSelectManager advColSelectManager))
        {
            materialType = advColSelectManager.materialType;
        }
    }

    public void onClick()
    {

        if (Utils.isStartScreenExists(gameObject.transform))
        {

            GameObject startScreen = GameObject.FindWithTag("StartScreen");
            Component[] dis_buts = startScreen.transform.GetComponentsInChildren<Button>();
            foreach (Button button in dis_buts)
            {

                button.interactable = true;

            }

        }

        CharacterStateManager characterState = gameManager.GetComponent<GameStateManager>().characterObject.GetComponent<CharacterStateManager>();

        string characterID = gameManager.GetComponent<GameStateManager>().characterID;

        string materialPath = $"{Application.streamingAssetsPath}/CharacterData/{characterID}/Materials/{materialType}_colour.json";
        Material plrMaterial = null;
        switch (materialType)
        {
            case "skin":
                plrMaterial = characterState.skinMaterial;
                break;
            case "outfit":
                plrMaterial = characterState.outfitMaterial;
                break;
            case "hair":
                plrMaterial = characterState.hairMaterial;
                break;
        }

        materialJSONData materialJSON = ScriptableObject.CreateInstance<materialJSONData>();
        materialJSON.fromMaterial(plrMaterial);
        FileManager.WriteBinary(materialJSON.toJson(),materialPath);
        GameObject.Destroy(gameObject.transform.parent.gameObject);
    }

}
