using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class WaveSpawnerBasic : MonoBehaviour
{
    [SerializeField] private Text waveCntTxt;
    [SerializeField] private float spawnRate = 3f;
    private float timeBetweenWaves = 5.0f; //
    private int enemyCnt = 1;
    [SerializeField] private int waveCnt = 0;
    [SerializeField] GameObject enemy;
    [SerializeField] Transform[] spawnPoints;
    private float searchCntDwn = 1f;

    void Start()
    {
        Debug.Log("Wave Complete");
    }

    // Update is called once per frame
    void Update()
    {
        waveCntTxt.text = "Round: " + waveCnt.ToString();
        StartCoroutine(waveSpawner());
    }

    bool checkWaveComplete()
    {
        searchCntDwn -= Time.deltaTime;
        if (searchCntDwn <= 0f)
        {
            Debug.Log("Searching!");
            searchCntDwn = 1f;
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                Debug.Log("True!");
                return true;
            }
        }
        return false;
    }

    IEnumerator waveSpawner()
    {
        if (Enumerable.Range(1,4).Contains(waveCnt))
            {
                enemyCnt = Convert.ToInt32(Math.Floor((Double) (waveCnt*(waveCnt/5+1) )));
            }
        else
        {
            Debug.Log("Stopped!");
            enemyCnt = Convert.ToInt32(Math.Floor(waveCnt*(waveCnt*0.15f)));

        }
        
        while(checkWaveComplete())
        {
            waveCnt += 1;
            for (int i=0; i < enemyCnt; i++)
            {
                Transform randomSpawn  = spawnPoints[UnityEngine.Random.Range(0,spawnPoints.Length)];
                GameObject enemyClone = Instantiate(enemy, randomSpawn.position, Quaternion.identity);
                yield return new WaitForSeconds(spawnRate);
            }
            spawnRate -= 0.1f;
        }

    }
}