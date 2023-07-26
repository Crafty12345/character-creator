using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShowPartSelector : MonoBehaviour
{

    public Transform canvas;
    public GameObject box;
    public string partType;

    PartDataScriptableObject partData;

    private void Start()
    {
        partData = Resources.Load<PartDataScriptableObject>("UI/options/" + partType);
    }

    public void onClick()
    {
        GameObject window = Resources.Load<GameObject>("Prefabs/UI/screens/empty_part_select_window");
        Sprite box_selected = Resources.Load<Sprite>("UI/textures/misc/empty_box/selected/selected");

        
        List<Sprite> icons = partData.GetSprites();

        GameObject sender = this.gameObject;
        GameObject window_panel = Instantiate(window, canvas);

        window_panel.GetComponent<PartSelectManager>().partType = partType;
        window_panel.GetComponent<PartSelectManager>().partData = partData;

        RectTransform window_panel_rect = window_panel.GetComponent<RectTransform>();
        float window_width = window_panel_rect.sizeDelta.x;
        float window_height = window_panel_rect.sizeDelta.y;

        float padding_x = 5.0f;
        float padding_y = 5.0f;
        float offset_x = 30.0f;
        float offset_y = 100;
        float box_size = box.GetComponent<RectTransform>().sizeDelta.x;
        float box_total_width = (box_size + padding_x);
        float box_total_height = (box_size + padding_y);
        int max_cols = (int)Math.Ceiling((decimal)((window_width + window_panel_rect.anchoredPosition.x) / box_total_width)) + 1;
        int max_rows = (int)Math.Ceiling((decimal)(Convert.ToDecimal(icons.Count) / Convert.ToDecimal(max_cols)));
        List<int> rows = Enumerable.Repeat(max_cols, max_rows).ToList();
        rows[rows.Count - 1] = (icons.Count % rows[rows.Count - 1]);
        List<GameObject> button_icons = new List<GameObject>();

        int i = 0;

        for (int r = 0; r < rows.Count; r++)
        {
            for (int c = 0; c < rows[r]; c++)
            {
                GameObject new_box = Instantiate(box, window_panel.transform);
                string new_box_tag = Utils.CapitaliseFirstLetter(partType) + "PartButton";
                new_box.tag = new_box_tag;

                Vector2 window_panel_position = window_panel_rect.anchoredPosition;
                Vector2 new_box_pos = new Vector2(((window_panel_position.x + offset_x) + (c * (box_total_width))), ((window_height / 2) - (offset_y + ((padding_y + box_total_height) * r))));
                new_box.GetComponent<RectTransform>().anchoredPosition = new_box_pos;

                Image new_box_icon = new_box.transform.Find("icon").gameObject.GetComponent<Image>();
                new_box.GetComponent<BoxDataManager>().boxID = i;
                new_box_icon.sprite = icons[i];
                new_box_icon.preserveAspect = true;
                new_box_icon.color = Color.white;
                i++;
            }
        }
    }

}
