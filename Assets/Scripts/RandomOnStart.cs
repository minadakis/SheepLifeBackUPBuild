using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomOnStart : MonoBehaviour
{
    public Sprite[] sprites;
    public float ypos;
    Vector3 temp1;
    private void Start()
    {
        temp1 = transform.position;
        temp1.z = temp1.y;
        transform.position = temp1;
        int index = Random.Range(0, sprites.Length);
        GetComponent<SpriteRenderer>().sprite = sprites[index];
       

    }

    private void FixedUpdate()
    {


            Vector3 pos = new Vector3(transform.position.x, transform.position.y, temp1.z - ClickToMove.Instance.transform.position.y-0.2f);
            transform.position = pos;

        
        
        
        
    }

}
