using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showAdvancedColourSelect : MonoBehaviour
{

    public void OnClick()
    {
        GameObject new_panel = Resources.Load<GameObject>("Prefabs/UI/screens/advanced_colour_select_window");
        new_panel = GameObject.Instantiate(new_panel,this.gameObject.transform.parent);
        string materialType = transform.parent.gameObject.GetComponent<BasicColourSelectManager>().materialType;
        new_panel.GetComponent<AdvancedColourSelectManager>().materialType = materialType;
        GameObject player = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameStateManager>().characterObject;
        switch (materialType)
        {
            case "skin":
                {

                    new_panel.GetComponent<AdvancedColourSelectManager>().old_colour = player.GetComponent<CharacterStateManager>().materialMap.Skin[0].GetComponent<Renderer>().material.color;
                    break;
                }
            case "outfit":
                {
                    new_panel.GetComponent<AdvancedColourSelectManager>().old_colour = player.GetComponent<CharacterStateManager>().materialMap.Outfit[0].GetComponent<Renderer>().material.color;
                    break;
                }
        }
    }

}
