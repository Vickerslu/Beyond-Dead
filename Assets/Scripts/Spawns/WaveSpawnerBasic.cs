using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class WaveSpawnerBasic : MonoBehaviour
{
    [SerializeField] private Text waveCntTxt;
    [SerializeField] public static float diffMulti = 1f;
    public float spawnRate = 2f;
    private int enemyCnt = 1;
    public int waveCnt = 0;

    [SerializeField] GameObject[] enemies;
    public List<Transform> spawnPoints;

    private float searchCntDwn = 1f;

    void Start()
    {
        // GameObject firstSpawn = GameObject.Find("Testrrr");
        // Transform firstSpawnTransform = firstSpawn.transform;
        // Debug.Log(firstSpawnTransform);
        // spawnPoints.Add(firstSpawnTransform);
        // Debug.Log(spawnPoints);
    }

    void Update()
    {
        waveCntTxt.text = "Round: " + waveCnt.ToString();
        StartCoroutine(waveSpawner());
    }

    // Occasionally checks if the current wave has ended (enemies still alive) (not constantly running in update for performance reasons)
    bool checkWaveComplete()
    {
        searchCntDwn -= Time.deltaTime;
        if (searchCntDwn <= 0f)
        {
            searchCntDwn = 1f;
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                return true;
            }
        }
        return false;
    }

    // Between rounds 1-4, spawn a certain number of enemies. Higher rounds, spawn enemeies using a different formula
    // Formula makes sure that the amount of enemies increases with the round number.
    // If the wave is complete, begin spawning another wave of enemy clones, increasing the round number and making the
    // enemies harder to kill. decrease the time between spawns to make it more intense. Random spawn points based off an array of spawn points.
    IEnumerator waveSpawner()
    {
        if (Enumerable.Range(1,4).Contains(waveCnt))
            {
                enemyCnt = Convert.ToInt32(Math.Floor(diffMulti * Convert.ToInt32(Math.Floor((Double) (waveCnt*(waveCnt/2+5) )))));
            }
        else
        {
            enemyCnt = Convert.ToInt32(Math.Floor(diffMulti * Convert.ToInt32(Math.Floor(waveCnt*(waveCnt*0.15f)))));

        }

        while(checkWaveComplete())
        {
            waveCnt += 1;
            for (int i=0; i < enemyCnt; i++)
            {
                Transform randomSpawn  = spawnPoints[UnityEngine.Random.Range(0,spawnPoints.Count)];
                GameObject enemyClone = Instantiate(enemies[UnityEngine.Random.Range(0,enemies.Length)], randomSpawn.position, Quaternion.identity);
                enemyClone.GetComponent<Enemy>().IncreaseHealth(waveCnt);
                yield return new WaitForSeconds(spawnRate);
            }
            if (spawnRate>1)
            {
                spawnRate -= 0.1f;
            }
        }
    }
}
