using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class on_category_click : MonoBehaviour
{
    public Button btn_head;
    // Start is called before the first frame update
    void Start()
    {
        btn_head.onClick.AddListener(delegate { onClick(btn_head.gameObject);});
    }

    void onClick(GameObject category)
    {
        //Debug.Log(category);
    }


}
