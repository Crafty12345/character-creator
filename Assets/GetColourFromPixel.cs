using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GetColourFromPixel : MonoBehaviour, IPointerEnterHandler
{

    public GameObject preview;
    RectTransform rect;
    Texture2D img_texture;
    PointerEventData mouse_data;
    bool is_hovered;

    void Awake()
    {
        rect = gameObject.GetComponent<RectTransform>();
        img_texture = GetComponent<Image>().sprite.texture;
    }

    void Update()
    {
        if (is_hovered) {
            if (Input.GetMouseButton(0))
            {
                Vector2 localPoint;
                if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, mouse_data.position, mouse_data.pressEventCamera, out localPoint))
                {
                    int x = Mathf.RoundToInt(localPoint.x + rect.rect.width / 2);
                    int y = Mathf.RoundToInt(localPoint.y + rect.rect.height / 2);
                    Color new_colour = img_texture.GetPixel(x, y);
                    preview.GetComponent<ColourPreviewManager>().raw_colour = new_colour;
                    preview.GetComponent<ColourPreviewManager>().update_preview();

                }
            }

        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_data = eventData;
        is_hovered = true;
        
    }

    public void OnPointerExit()
    {
        mouse_data = null;
        is_hovered = false;
    }

}
