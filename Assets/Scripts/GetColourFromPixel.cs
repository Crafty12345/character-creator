using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class GetColourFromPixel : MonoBehaviour, IPointerEnterHandler
{

    public GameObject preview;
    public GameObject pickerIcon;
    RectTransform rect;
    Texture2D img_texture;
    PointerEventData mouse_data;
    bool is_hovered;
    Vector2 rainbow_dims;

    void Awake()
    {
        rainbow_dims = new Vector2(134, 180);
        rect = gameObject.GetComponent<RectTransform>();
        img_texture = GetComponent<Image>().sprite.texture;
    }

    void Update()
    {
        Vector2 localPoint;
        if ((IsPointerOverColourSpectrum() && Input.GetMouseButton(0)) &&
                (RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, mouse_data.position, mouse_data.pressEventCamera, out localPoint))){
                    pickerIcon.GetComponent<RectTransform>().transform.localPosition = localPoint;
                    int x = Mathf.RoundToInt(localPoint.x + rect.rect.width / 2);
                    Debug.Log(x);
                    //int y = Mathf.RoundToInt(localPoint.y + rect.rect.height / 2);
                    Color new_colour = img_texture.GetPixel(x, Convert.ToInt16(rainbow_dims.y/2));
                    preview.GetComponent<ColourPreviewManager>().raw_colour = new_colour;
                    preview.GetComponent<ColourPreviewManager>().update_preview();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_data = eventData;
        
    }


    public bool IsPointerOverColourSpectrum()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raycastResultList = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResultList);
        foreach (RaycastResult raycast in raycastResultList )
        {
            if (raycast.gameObject.GetComponent<colourSpectrumMarker>() != null)
            {
                return true;

            }
        }
        return false;
    }

}
