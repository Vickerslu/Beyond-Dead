using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Text valueText;
    void Start()
    {
        SoundManager.Instance.ChangeMasterVolume(_slider.value);
        _slider.onValueChanged.AddListener(val => SoundManager.Instance.ChangeMasterVolume(val));
        _slider.onValueChanged.AddListener(val => TextUpdate(val));
    }
    void TextUpdate(float value)
    {
        valueText.text = _slider.value + "";
    }
}
