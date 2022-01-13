using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DifficultyDropDownMenu : MonoBehaviour
{
    public void HandleInputData(int val)
    {
        if (val == 0){
            WaveSpawnerBasic.diffMulti = 0.5f;
        }
        if (val == 1){
            WaveSpawnerBasic.diffMulti = 1f;
        }
        if (val == 2){
            WaveSpawnerBasic.diffMulti = 1.5f;
        }
    }
}
