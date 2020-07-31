using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEvent : MonoBehaviour
{
    AudioManager audioManager;

    //When sheep is eating the correct bush then we call this function to make the happy sound for the shepard
    public void ShepardHappy()
    {
        AudioManager.instance.Play("ShepardHappy1");
    }

    //Every time the sheep is eating a false bush the shepard is making of these sounds in random
    public void ShepardMad()
    {
        int num = Random.Range(1,5);
        if (num == 1)
        {
            AudioManager.instance.Play("ShepardMad1");
        }
        else if (num == 2)
        {
            AudioManager.instance.Play("ShepardMad2");
        }
        else if (num == 3)
        {
            AudioManager.instance.Play("ShepardMad3");
        }
        else if (num == 4)
        {
            AudioManager.instance.Play("ShepardMad4");
        }
    }

    //Function to call the cane hit on the ground when the sheep is eating the wrong bush
    public void CaneHit()
    {
        AudioManager.instance.Play("CaneHit");
    }

   
}
