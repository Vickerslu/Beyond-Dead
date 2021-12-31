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
                Debug.Log("E was pressed");
                interactAction.Invoke();
            }
        }
    }
}