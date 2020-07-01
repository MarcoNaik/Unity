
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Diagnostics;

public class DrawSquare : MonoBehaviour
{
    private Vector2 startMousePos;
    private Vector2 updatedMousePos;
    Color rectColor = new Color(0f, 0.61f, 0.1f, 0.29f);
    Color rectBorderColor = new Color(0.8f, 0.8f, 0.95f);
    private Texture2D rectTexture;
    Rect rect;

    private void OnEnable()
    {
        rectTexture = new Texture2D(1, 1);
        rectTexture.SetPixel(0, 0, rectColor);
        startMousePos = Input.mousePosition;
        startMousePos.y = Screen.height - startMousePos.y;
        
    }

    void Update()
    {
        updatedMousePos = Input.mousePosition;
        updatedMousePos.y = Screen.height - updatedMousePos.y;
        //rect= new Rect(startMousePos,  new Vector2(100 , 100));
        rect= new Rect(startMousePos,  updatedMousePos-startMousePos);
    }

    private void OnGUI()
    {
        GUI.DrawTexture(rect, rectTexture);
    }
}