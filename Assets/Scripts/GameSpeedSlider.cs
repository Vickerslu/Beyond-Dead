using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSpeedSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    void Start()
    {
        Enemy.speedMultiplier = _slider.value;
        _slider.onValueChanged.AddListener(val => Enemy.speedMultiplier = val);
    }
}
