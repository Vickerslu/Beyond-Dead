using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSpeedSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Text valueText;
    void Start()
    {
        Enemy.speedMultiplier = _slider.value;
        _slider.onValueChanged.AddListener(val => Enemy.speedMultiplier = val);
        _slider.onValueChanged.AddListener(val => TextUpdate(val));
    }
    void TextUpdate(float value)
    {
        valueText.text = Mathf.RoundToInt(_slider.value * 100f) / 100f + "";
    }
}
