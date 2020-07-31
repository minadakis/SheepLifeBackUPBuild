using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundScaler : MonoBehaviour
{
    AudioManager audioManager;
    public List<Sound> soundList;
    public GameObject audioManagerObj;
    public GameObject noSounds;
    public GameObject mediumSounds;
    public GameObject highSounds;
    public Sprite noSoundImage;
    public Sprite mediumSoundsImage;
    public Sprite highSoundsImage;
    public Sprite noSoundImageGreen;
    public Sprite mediumSoundsImageGreen;
    public Sprite highSoundsImageGreen;

    //This is the script which control on main menu the sound panel
    //When we start the game we want our sound to be on the highest level
    public void Start()
    {
        highSounds.GetComponent<Image>().sprite = highSoundsImageGreen;
    }

    //If we click the noSound button then it get greens and we mute all the game sounds
    public void NoSounds()
    {
        noSounds.GetComponent<Image>().sprite = noSoundImageGreen;
        mediumSounds.GetComponent<Image>().sprite = mediumSoundsImage;
        highSounds.GetComponent<Image>().sprite = highSoundsImage;

        foreach (var s in AudioManager.instance.sounds)
        {
            s.volume = 0f;
            AudioManager.instance.Volume(s.name);
        }
      
        
    }

    //If we click the mediumSounds button then it get greens and we have all our sounds in a medium state
    public void MediumSounds()
    {

        noSounds.GetComponent<Image>().sprite = noSoundImage;
        mediumSounds.GetComponent<Image>().sprite = mediumSoundsImageGreen;
        highSounds.GetComponent<Image>().sprite = highSoundsImage;


        audioManagerObj.GetComponent<AudioManager>().sounds[0].volume = 0.2f;
        audioManagerObj.GetComponent<AudioManager>().sounds[1].volume = 0.4f;        
        audioManagerObj.GetComponent<AudioManager>().sounds[2].volume = 0.25f;
        audioManagerObj.GetComponent<AudioManager>().sounds[3].volume = 0.25f;
        audioManagerObj.GetComponent<AudioManager>().sounds[4].volume = 0.25f;
        audioManagerObj.GetComponent<AudioManager>().sounds[5].volume = 0.25f;
        audioManagerObj.GetComponent<AudioManager>().sounds[6].volume = 0.25f;
        audioManagerObj.GetComponent<AudioManager>().sounds[7].volume = 0.25f;
        audioManagerObj.GetComponent<AudioManager>().sounds[8].volume = 0.25f;
        audioManagerObj.GetComponent<AudioManager>().sounds[9].volume = 0.25f;
        audioManagerObj.GetComponent<AudioManager>().sounds[10].volume = 0.25f;
        audioManagerObj.GetComponent<AudioManager>().sounds[11].volume = 0.25f;
        audioManagerObj.GetComponent<AudioManager>().sounds[12].volume = 0.25f;
        audioManagerObj.GetComponent<AudioManager>().sounds[13].volume = 0.25f;
        audioManagerObj.GetComponent<AudioManager>().sounds[14].volume = 0.25f;
        audioManagerObj.GetComponent<AudioManager>().sounds[15].volume = 0.3f;
        audioManagerObj.GetComponent<AudioManager>().sounds[16].volume = 0.15f;
        audioManagerObj.GetComponent<AudioManager>().sounds[17].volume = 0.5f;
        foreach (var s in AudioManager.instance.sounds)
        {
            AudioManager.instance.Volume(s.name);
        }
       
        
    }

    //If we press the highsounds button then we make it green and make all the game sounds to be in the highest level
    public void HighSounds()
    {

        noSounds.GetComponent<Image>().sprite = noSoundImage;
        mediumSounds.GetComponent<Image>().sprite = mediumSoundsImage;
        highSounds.GetComponent<Image>().sprite = highSoundsImageGreen;

        audioManagerObj.GetComponent<AudioManager>().sounds[0].volume = 0.45f;
        audioManagerObj.GetComponent<AudioManager>().sounds[1].volume = 0.8f;
        audioManagerObj.GetComponent<AudioManager>().sounds[2].volume = 0.5f;
        audioManagerObj.GetComponent<AudioManager>().sounds[3].volume = 0.5f;
        audioManagerObj.GetComponent<AudioManager>().sounds[4].volume = 0.5f;
        audioManagerObj.GetComponent<AudioManager>().sounds[5].volume = 0.5f;
        audioManagerObj.GetComponent<AudioManager>().sounds[6].volume = 0.5f;
        audioManagerObj.GetComponent<AudioManager>().sounds[7].volume = 0.5f;
        audioManagerObj.GetComponent<AudioManager>().sounds[8].volume = 0.5f;
        audioManagerObj.GetComponent<AudioManager>().sounds[9].volume = 0.5f;
        audioManagerObj.GetComponent<AudioManager>().sounds[10].volume = 0.5f;
        audioManagerObj.GetComponent<AudioManager>().sounds[11].volume = 0.5f;
        audioManagerObj.GetComponent<AudioManager>().sounds[12].volume = 0.5f;
        audioManagerObj.GetComponent<AudioManager>().sounds[13].volume = 0.5f;
        audioManagerObj.GetComponent<AudioManager>().sounds[14].volume = 0.5f;
        audioManagerObj.GetComponent<AudioManager>().sounds[15].volume = 0.6f;
        audioManagerObj.GetComponent<AudioManager>().sounds[16].volume = 0.3f;
        audioManagerObj.GetComponent<AudioManager>().sounds[17].volume = 1f;
        foreach (var s in AudioManager.instance.sounds)
        {
            AudioManager.instance.Volume(s.name);
        }

    }
}
