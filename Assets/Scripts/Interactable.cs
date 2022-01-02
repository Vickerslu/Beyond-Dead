using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    public bool inRange;
    public UnityEvent interactAction;

    // Update is called once per frame
    void Update()
    {
        if(inRange) {
            if(Keyboard.current.eKey.wasPressedThisFrame) {
                interactAction.Invoke();
            }
        }
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag == "Player")
        {
            inRange = true;
            Debug.Log("In range");
        }
    }

    void OnTriggerExit2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag == "Player")
        {
            inRange = false;
            Debug.Log("Out of range");
        }
    }
}