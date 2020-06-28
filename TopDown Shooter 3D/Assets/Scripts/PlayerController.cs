using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : AbstractUnit
{
    public float movementSpeed = 5f;
    private Rigidbody rb;
    
    private Vector3 movement;
    
    private Camera cam;

    private Ray cameraRay;

    private Plane groundPlane;
    private Vector3 pointToLook;

    public GunController gun;
    
    


    private void Start()
    {
        isAlive = true;
        currentHitPoints = hitPoints;
        rb = GetComponent<Rigidbody>();
        cam = FindObjectOfType<Camera>();
        groundPlane = new Plane(Vector3.up, Vector3.zero);
    }

    void Update()
    {
        CheckHp();
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");

        cameraRay = cam.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            gun.isFiring = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            gun.isFiring = false;
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            pointToLook.y = transform.position.y;
            transform.LookAt(pointToLook);
        }

        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }

    protected override void Kill()
    {
        Destroy(gameObject);
    }
    
}
