using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private AudioSource _musicScource, _effectsScource;

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } 
        else {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip) {
        _effectsScource.PlayOneShot(clip);
    }

    public void ChangeMasterVolume(float value){
        AudioListener.volume = value/100;  //divide by 100 because sliders range is 0-100
    }
    public void ChangeEffectsVolume(float value){
        _effectsScource.volume = value/100;
    }
}
