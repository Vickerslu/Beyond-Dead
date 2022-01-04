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
        _effectsScource.volume = 0.1f;  // bullet sound too loud had to hard code the volume
        _effectsScource.PlayOneShot(clip);
    }

    public void ChangeMasterVolume(float value){
        AudioListener.volume = value/100;
    }
}
