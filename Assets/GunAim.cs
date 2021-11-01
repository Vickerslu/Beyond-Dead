using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAim : MonoBehaviour
{
    // Reference: https://docs.unity3d.com/Manual/class-Transform.html
    private Transform aimTransform;
    private Camera camera;
    public Transform firePoint;
    public GameObject bulletPrefab;


    // Reference: https://gamedevbeginner.com/start-vs-awake-in-unity/
    void Awake()
    {
        camera = Camera.main;
        // adds reference to Aim object
        aimTransform = transform.Find("Aim");
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
        Shoot();
    }

    private void Aim() {
        Vector3 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        // Reference: https://www.youtube.com/watch?v=fuGQFdhSPg4
        Vector3 aimDir = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0,0,angle);
    }

    private void Shoot() {
        if (Input.GetButtonDown("Fire1")) {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}
