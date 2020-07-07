using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Billboard : MonoBehaviour
{
    public Transform cam;

    private void Awake()
    {
        if (Camera.main != null) cam = Camera.main.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(transform.position+ cam.forward);
    }
}
