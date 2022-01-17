using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerInteract : MonoBehaviour
{
    public bool entered;
    public UnityEvent interactAction;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag == "Player")
        {
            if(!entered) {
                entered = true;
                interactAction.Invoke();
                Debug.Log("Entered Zone");
            }
        }
    }

}
