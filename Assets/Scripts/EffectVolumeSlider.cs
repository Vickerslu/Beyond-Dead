using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EffectVolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    void Start()
    {
        SoundManager.Instance.ChangeEffectsVolume(_slider.value);
        _slider.onValueChanged.AddListener(val => SoundManager.Instance.ChangeEffectsVolume(val));
    }
}
