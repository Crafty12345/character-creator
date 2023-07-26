using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PartSelectManager : MonoBehaviour
{

    public string partType;
    public PartDataScriptableObject partData;
    public List<GameObject> parts = new List<GameObject>();

    void Start()
    {
        GameObject character = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameStateManager>().characterObject;

        switch (partType)
        {
            case "hair":
                parts.Add(character.GetComponent<CharacterStateManager>().partObject.HairObject);
                break;
        }
    }

}
