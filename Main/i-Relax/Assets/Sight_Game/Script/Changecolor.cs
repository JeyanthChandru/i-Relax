using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changecolor : MonoBehaviour {
    public Color startColor;
    public Color mouseOverColor;
    public Renderer rend;
    bool mouseOver = false;
    void Start()
    {
        rend = GetComponent<Renderer>();
    }
    void OnMouseEnter()
    {
        mouseOver = true;
        rend.material.SetColor("_Color", mouseOverColor);
    }
    void OnMouseOver()
    {
        print("over");
        rend.material.color -= new Color(0.1F, 0, 0) * Time.deltaTime;
    }
    void OnMouseExit()
    {
        mouseOver = false;
        rend.material.SetColor("_Color", startColor);
    }
}
