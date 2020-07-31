using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolesMovingOnZ : MonoBehaviour
{
    private Vector3 newMovevment;
    private Animator playerAnim;

    public void Start()
    {
        newMovevment = transform.position;
        newMovevment.z = newMovevment.y;
        transform.position = newMovevment;

        if (ClickToMove.Instance != null)
        {
          
            playerAnim = ClickToMove.Instance.GetComponent<Animator>();
        }
       
            
    }

    //On this fixedUpdate if clicktomove instance is different from null and our player is moving,then we change the holes.z depending the player position
    //All that to secure that sheep is sometimes in front of the bush or behind him.
    private void FixedUpdate()
    {
        
        if (ClickToMove.Instance != null&& playerAnim.GetFloat("speed")>0)
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, newMovevment.z - ClickToMove.Instance.transform.position.y + 0.08f);
            transform.position = pos;
        }
            
       
    }
}
