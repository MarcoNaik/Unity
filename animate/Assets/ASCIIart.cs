using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASCIIart : MonoBehaviour
{
    Texture texture;

    private void Awake()
    {
        texture = GetComponent<Camera>().targetTexture;
        
    }

    private void Update()
    {
       
    }
}
