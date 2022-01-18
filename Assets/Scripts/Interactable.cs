using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public bool inRange;
    private InputActions playerInput;
    public UnityEvent interactAction;
    [SerializeField] public Text EToInteractText;

    void Awake() {
        playerInput = new InputActions();
    }

    void Start() {
        playerInput.Player.Interact.performed += _ => Interact();
    }

    void OnEnable(){
        playerInput.Enable();
    }

    void OnDisable(){
        playerInput.Disable();
    }

    void Interact() {
        if(inRange) {
            interactAction.Invoke();
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag == "Player")
        {
            inRange = true;
            EToInteractText.text = "Press E to Interact";
        }
    }

    void OnTriggerExit2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag == "Player")
        {
            inRange = false;
            EToInteractText.text = "";
        }
    }
}
