using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    public Material material;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Image>().material = material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
