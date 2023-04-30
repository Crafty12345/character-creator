using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setGradient : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Material gradient = Resources.Load<Material>("Materials/SpectrumMaterial");
        gameObject.GetComponent<Image>().material = gradient;
    }

}