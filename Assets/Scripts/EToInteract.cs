using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EToInteract : MonoBehaviour
{
    [SerializeField] public Text EToInteractText;

    // Update is called once per frame
    void Update()
    {
        if (Interactable.inRange) {
            EToInteractText.text = "Press E to Interact";
        } else {
            EToInteractText.text = "";
        }
    }
}
