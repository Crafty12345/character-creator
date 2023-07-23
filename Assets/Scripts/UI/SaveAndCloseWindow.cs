using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveAndCloseWindow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

        GameObject.Destroy(gameObject.transform.parent.gameObject);
    }

}
