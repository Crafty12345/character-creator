using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class showBasicColourSelector : MonoBehaviour
{

    private class DecColour
    {
        public Decimal r;
        public Decimal g;
        public Decimal b;
        public Decimal a;

        public DecColour fromRGBA(Decimal R, Decimal G, Decimal B, Decimal A)
        {
            DecColour _clr = new DecColour();
            _clr.r = R;
            _clr.g = G;
            _clr.b = B;
            _clr.a = A;
            return _clr;
        }

        public DecColour convertToDecColour(Color _colour)
        {
            DecColour _decColour = new DecColour();
            _decColour.r = (Decimal)_colour.r;
            _decColour.g = (Decimal)_colour.g;
            _decColour.b = (Decimal)_colour.b;
            _decColour.a = (Decimal)_colour.a;
            return _decColour;
        }
        public DecColour Floor(int n)
        {
            decimal _r = Math.Floor((this.r * (decimal)Math.Pow(10, n))) / (decimal)Math.Pow(10,n);
            decimal _g = Math.Floor((this.g * (decimal)Math.Pow(10, n))) / (decimal)Math.Pow(10, n);
            decimal _b = Math.Floor((this.b * (decimal)Math.Pow(10, n))) / (decimal)Math.Pow(10, n);
            decimal _a = Math.Floor((this.a * (decimal)Math.Pow(10, n))) / (decimal)Math.Pow(10, n);
            return this.fromRGBA(_r, _g, _b, _a);
        }
    }

    private bool checkColourSimilarity(Color colour1, Color colour2, float threshold)
    {
        float min_r = colour1.r * (1 - threshold);
        float max_r = colour1.r * (1 + threshold);

        float min_g = colour1.g * (1 - threshold);
        float max_g = colour1.g * (1 + threshold);

        float min_b = colour1.b * (1 - threshold);
        float max_b = colour1.b * (1 + threshold);

        if (
            (colour2.r >= min_r) && (colour2.r <= max_r) &&
            (colour2.g >= min_g) && (colour2.g <= max_g) &&
            (colour2.b >= min_b) && (colour2.b <= max_b))
        {
            return true;
        }
        return false;
    }


    public colourGroupScriptableObjectManager colourGroup;
    public GameObject window;
    public GameObject box;
    public Transform canvas;
    public Material current_colour_material;

    public void showPanel()
    {

        Debug.Log(current_colour_material.color);
        Sprite box_selected = Resources.Load<Sprite>("UI/textures/misc/empty_box/selected/selected");
        GameObject sender = this.gameObject;
        GameObject window_panel = Instantiate(window, canvas);
        RectTransform window_panel_rect = window_panel.GetComponent<RectTransform>();
        float window_width = window_panel_rect.sizeDelta.x;
        float window_height = window_panel_rect.sizeDelta.y;

        float padding_x = 5.0f;
        float padding_y = 5.0f;
        float offset_x = 40.0f;
        float offset_y = 80;
        float box_size = box.GetComponent<RectTransform>().sizeDelta.x;
        float box_total_width = (box_size + padding_x);
        float box_total_height = (box_size + padding_y);
        int max_cols = (int)Math.Ceiling((decimal)((window_width + window_panel_rect.anchoredPosition.x) / box_total_width)) + 1;
        int max_rows = (int)Math.Ceiling((decimal)(Convert.ToDecimal(colourGroup.Colours.Count) / Convert.ToDecimal(max_cols)));
        List<int> rows = Enumerable.Repeat(max_cols, max_rows).ToList();
        string dbgString = $"{max_cols}, {max_rows}, {colourGroup.Colours.Count}";
        rows[rows.Count - 1] = (colourGroup.Colours.Count % rows[rows.Count - 1]);
        List<GameObject> buttons = new List<GameObject>();
        List<GameObject> button_icons = new List<GameObject>();
        for (int r = 0; r < rows.Count; r++)
        {
            for (int c = 0; c < rows[r]; c++)
            {

                int i = (c + ((r) * max_cols))+1;

                GameObject new_box = Instantiate(box, window_panel.transform);


                Vector2 window_panel_position = window_panel_rect.anchoredPosition;
                Vector2 new_box_pos = new Vector2(((window_panel_position.x + offset_x) + (c * (box_total_width))), ((window_height / 2) - (offset_y + ((padding_y + box_total_height) * r))));
                new_box.GetComponent<RectTransform>().anchoredPosition = new_box_pos;
                buttons.Add(new_box);
                button_icons.Add(new_box.transform.Find("icon").gameObject);
            }
        }
        for (int i = 0; i < button_icons.Count; i++)
        {
            button_icons[i].GetComponent<Image>().color = colourGroup.Colours[i];
            if (checkColourSimilarity(colourGroup.Colours[i], current_colour_material.color, 0.05f))
            {
                buttons[i].GetComponent<Image>().sprite = box_selected;
                buttons[i].GetComponent<boxIconManager>().Selected = true;
            }
        }
    }

}