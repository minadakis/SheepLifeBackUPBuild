using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomOnStart : MonoBehaviour
{
    public Sprite[] sprites;

    //When we gonna create a new obstacle  then we choose a random sprite from the ones we have
    private void Start()
    {
        int index = Random.Range(0, sprites.Length);
        GetComponent<SpriteRenderer>().sprite = sprites[index];
    }

  

}
