using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    [SerializeField] GameObject target;
    NavMeshAgent agent;
    
    // Start is called before the first frame update
    void Start() {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = UnityEngine.Random.Range(4f,7f);
        target = GameObject.Find("Player");
        // moveSpeed = UnityEngine.Random.Range(5,5f);
    }

    void Update() {
        agent.SetDestination(target.transform.position);
    }
}
