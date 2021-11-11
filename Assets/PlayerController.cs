using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputActions playerInput;
    private Vector2 movement;
    private Vector2 mousePos;
    private Rigidbody2D rb;
    [SerializeField] private float speed = 10f;
    [SerializeField] Camera camera;
    [SerializeField] private float stamina = 200f;

    


    private void Awake(){
        playerInput = new InputActions();
        rb = GetComponent<Rigidbody2D>();
        camera = Camera.main;
    }

    private void OnEnable(){
        playerInput.Enable();

        playerInput.Player.Move.performed += OnMovement;
        playerInput.Player.Move.canceled += OnMovement;
        
        playerInput.Player.Look.performed += OnMousePos;
    }

    private void OnDisable(){
        playerInput.Disable();
    }

    private void OnMovement(InputAction.CallbackContext context){
        movement = context.ReadValue<Vector2>();
    }

    private void OnMousePos(InputAction.CallbackContext context){
        mousePos = camera.ScreenToWorldPoint(context.ReadValue<Vector2>());
    }

    private void FixedUpdate(){
        rb.AddForce(movement * speed);

        Vector2 facingDirection = mousePos - rb.position;
        float angle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;
        rb.MoveRotation(angle);
    }

    
}
