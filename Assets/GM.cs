using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Bullet bulletScript;
    // Start is called before the first frame update
    void Start()
    {
        bulletScript = bulletPrefab.GetComponent<Bullet>();
        bulletScript.damage = 30;
    }

    // Update is called once per frame
    void Update()
    {
        SkipRounds();
    }

    void SkipRounds()
    {
        if(Input.GetKeyDown("space"))
        {
            Debug.Log("Activated");
            GameObject ws = GameObject.Find("WaveSpawner");
            WaveSpawnerBasic wsScript = ws.GetComponent<WaveSpawnerBasic>();
            wsScript.waveCnt = 30;
            wsScript.spawnRate = 1f;
            bulletScript.damage = 332;
        }
    }
}