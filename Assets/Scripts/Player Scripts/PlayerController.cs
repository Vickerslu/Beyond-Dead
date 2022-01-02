using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputActions playerInput;
    private Vector2 movement;
    private Vector3 mousePositionInWorld;

    private Rigidbody2D rb;
    private Camera mainCamera;

    [SerializeField] public float speed = 10f;
    [SerializeField] public float sprintSpeed;
    [SerializeField] private float movementVelocity = 5f;
    public bool isSprinting;

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletDirection;

    // instantiate player input into variable and set rb
    private void Awake(){
        playerInput = new InputActions();
        rb = GetComponent<Rigidbody2D>();
    }

    // sets main camera to variable, calls PlayerShoot when user clicks
    private void Start(){
        sprintSpeed = speed*1.5f;
        mainCamera = Camera.main;
        playerInput.Player.Fire.performed += _ => PlayerShoot();
    }

    //  get mouse pos, create bullet with correct attributes
    private void PlayerShoot(){
        if (!PauseMenu.GameIsPaused){
            Vector2 mousePositionOnScreen = playerInput.Player.Look.ReadValue<Vector2>();
            mousePositionInWorld = mainCamera.ScreenToWorldPoint(mousePositionOnScreen);

            GameObject g = Instantiate(bullet, bulletDirection.position, bulletDirection.rotation);
            g.SetActive(true);
        }
    }

    private void OnEnable(){
        playerInput.Enable();
    }

    void OnDisable(){
        playerInput.Disable();
    }

    // get mouse pos, do math to calculate rotation ammount, rotate player. Also move player using AddForce
    void Update(){
        if (!PauseMenu.GameIsPaused){
            //rotation
            Vector2 mousePositionOnScreen = playerInput.Player.Look.ReadValue<Vector2>();
            mousePositionInWorld = mainCamera.ScreenToWorldPoint(mousePositionOnScreen);
            Vector3 targetDirection = mousePositionInWorld - transform.position;
            // quaternion.euler rotatoin https://docs.unity3d.com/ScriptReference/Quaternion.Euler.html
            float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        }

        //movement
        Vector3 movement = playerInput.Player.Move.ReadValue<Vector2>() * movementVelocity;
        if(isSprinting) {
            rb.AddForce(movement * sprintSpeed * Time.deltaTime);
        }
        else {
            rb.AddForce(movement * speed * Time.deltaTime);
        }
    }
}
