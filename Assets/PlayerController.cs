using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputActions playerInput;
    private Vector2 movement;
    private Vector3 mouseWorldPos;
    private Rigidbody2D rb;
    private Camera mainCamera;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float movementVelocity = 5f;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletDirection;

    


    private void Awake(){
        playerInput = new InputActions();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start(){
        mainCamera = Camera.main;
        playerInput.Player.Fire.performed += _ => PlayerShoot();
    }
    private void PlayerShoot(){
        Vector2 mousePosition = playerInput.Player.Look.ReadValue<Vector2>();
        mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);

        GameObject g = Instantiate(bullet, bulletDirection.position, bulletDirection.rotation);
        g.SetActive(true);
    }

    private void OnEnable(){
        playerInput.Enable();
    }

    void OnDisable(){
        playerInput.Disable();
    }


    void Update(){
        //rotation
        Vector2 mouseScreenPos = playerInput.Player.Look.ReadValue<Vector2>();
        mouseWorldPos = mainCamera.ScreenToWorldPoint(mouseScreenPos);

        Vector3 targetDirection = mouseWorldPos - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        //movement
        Vector3 movement = playerInput.Player.Move.ReadValue<Vector2>() * movementVelocity;
        rb.AddForce(movement * speed * Time.deltaTime);
    }
}
