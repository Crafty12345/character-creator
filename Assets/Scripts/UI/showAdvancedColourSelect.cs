using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showAdvancedColourSelect : MonoBehaviour
{

    public void OnClick()
    {
        GameObject new_panel = Resources.Load<GameObject>("Prefabs/UI/screens/advanced_colour_select_window");
        GameObject.Instantiate(new_panel,this.gameObject.transform.parent);
        
    }

}
