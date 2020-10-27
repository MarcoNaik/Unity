using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MouseSensitivity = 100.0f;
    
    //esto pa que no se de la vuelta la comara al mirar pa arriba/abajo
    public float VerticalClampAngle = 80.0f;
    
    public float MoveSpeed = 5;
    public float gravity = -9.81f;
    public float jumpHeight = 3;
    
    
    //An empty object as a child en los pies del personaje.
    public Transform groundCheck;
    
    //Aqui ponis las capas que queris que cuenten as ground.
    public LayerMask groundMask;
    
    //aqui ponis la camarita que deberia estar como child en la herarchy
    public Transform cameraTransform;

   
    private CharacterController controller;
    
    
    private float MouseLookRotationX = 0f;
    private bool IsGrounded;
    private Vector3 velocity;
    
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = FindObjectOfType<CharacterController>();
    }

  
    void Update()
    { 
        if(Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        UpdateMovement();
        
        UpdateMouseLook();
    }
    
    private void UpdateMouseLook()
    {
        if (Input.GetMouseButtonDown(0) && Cursor.lockState == CursorLockMode.None)
            Cursor.lockState = CursorLockMode.Locked;

        Vector2 mousePos = new Vector2(Input.GetAxis("Mouse X")* MouseSensitivity * Time.deltaTime, -Input.GetAxis("Mouse Y")* MouseSensitivity * Time.deltaTime);
        
        MouseLookRotationX += mousePos.y;
        MouseLookRotationX = Mathf.Clamp(MouseLookRotationX, -VerticalClampAngle, VerticalClampAngle);
        
        cameraTransform.localRotation = Quaternion.Euler(MouseLookRotationX, 0f, 0f);
        
        transform.Rotate(Vector3.up * mousePos.x);
    }

    private void UpdateMovement()
    {
        float speedMultiplier = 1.0f;
        if (Input.GetKey(KeyCode.LeftShift))
            speedMultiplier = 2.0f;
        
        
        
        IsGrounded = Physics.CheckSphere(groundCheck.position, 0.4f, groundMask);
        
        if (IsGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 moveDirection = transform.right * Input.GetAxis("Horizontal") +
                                transform.forward * Input.GetAxis("Vertical");
        
        controller.Move(moveDirection * MoveSpeed * speedMultiplier * Time.deltaTime);
       

        if (Input.GetKey(KeyCode.Space) && IsGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        
        velocity.y += gravity * Time.deltaTime;
        
        controller.Move(velocity * Time.deltaTime);



    }

   
}
