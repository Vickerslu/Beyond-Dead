using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    private GameObject target;
    private Vector3 offset = new Vector3(0,0,-1);
    private Vector3 desiredPosition;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
    }

    //https://www.youtube.com/watch?v=s4Yex7oliwQ&ab_channel=Chris%27Tutorials
    void FixedUpdate()
    {
        if (target)
        {
            // where player is 
            desiredPosition = new Vector3(
                target.transform.position.x + offset.x,
                target.transform.position.y + offset.y,
                target.transform.position.z + offset.z
            );

            // where camera should be to give smooth movement effect
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }
}
