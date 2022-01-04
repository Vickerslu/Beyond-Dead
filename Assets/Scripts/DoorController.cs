using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] public int price;

    public void Buy()
    {
        if(Score.score >= price) {
            Score.score -= price;
            Destroy(gameObject);
        }
    }
}
