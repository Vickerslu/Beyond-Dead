using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSetActive : MonoBehaviour
{
    private Transform spawnPoint;
    [SerializeField] private WaveSpawnerBasic spawner;

    public void SetActive()
    {
        spawnPoint = gameObject.transform;
        spawner.spawnPoints.Add(spawnPoint);
        Debug.Log(spawner.spawnPoints);
    }
}
