using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetNewPart : MonoBehaviour
{

    string partType;
    GameObject character;

    PartDataData partData;


    public void Start()
    {
        partType = transform.parent.gameObject.GetComponent<PartSelectManager>().partType;
        character = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameStateManager>().characterObject;
        int boxID = gameObject.GetComponent<BoxDataManager>().boxID;
        partData = transform.parent.gameObject.GetComponent<PartSelectManager>().partData.PartDataList[boxID];
    }

    public void onClick()
    {

        List<GameObject> parts = transform.parent.gameObject.GetComponent<PartSelectManager>().parts;

        Transform parent = null;
        switch (partType)
        {
            case "hair":
                parent = character.GetComponent<CharacterStateManager>().partObject.HairObject.transform.parent;
                break;
        }

        GameObject new_part = GameObject.Instantiate(partData.GObject, parent: parent);
        new_part.transform.localPosition = partData.partOffset;

        switch (partType)
        {
            case "hair":
                if(new_part.transform.GetChild(0).gameObject.TryGetComponent<MeshRenderer>(out MeshRenderer mesh))
                {
                    mesh.material = character.GetComponent<CharacterStateManager>().hairMaterial;
                }
                character.GetComponent<CharacterStateManager>().partObject.HairObject = new_part;
                break;
        }

        foreach (GameObject part in parts)
        {
            GameObject.Destroy(part);
        }
        parts.Clear();
        parts.Add(new_part);
        transform.parent.GetComponent<PartSelectManager>().parts = parts;
    }

}
