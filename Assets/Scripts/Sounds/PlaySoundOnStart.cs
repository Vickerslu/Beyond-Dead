using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script added to bullets prefabs that plays sound when its created

public class PlaySoundOnStart : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    void Start()
    {
        SoundManager.Instance.PlaySound(_clip);
    }

}
