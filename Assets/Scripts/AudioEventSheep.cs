using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEventSheep : MonoBehaviour
{
    AudioManager audioManager;

    public void SheepEating()
    {
        AudioManager.instance.Play("SheepEating");
    }

    public void SheepVoice()
    {

        AudioManager.instance.Play("SheepSound5");
    }

    public void SheepMovingSound()
    {
        AudioManager.instance.Play("SheepMoving");
    }
}
