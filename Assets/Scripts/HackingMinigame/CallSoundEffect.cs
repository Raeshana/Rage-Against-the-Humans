using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallSoundEffect : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindWithTag("Audio").GetComponent<AudioManager>();
    }

    public void PlaySound() {
        audioManager.PlaySFX(audioManager.Hacking);
    }
}
