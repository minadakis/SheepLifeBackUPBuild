using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolesMovingOnZ : MonoBehaviour
{
    Vector3 newMovevment;
    public void Start()
    {
        newMovevment = transform.position;
        newMovevment.z = newMovevment.y;
        transform.position = newMovevment;
    }

    private void FixedUpdate()
    {

       
       

            Vector3 pos = new Vector3(transform.position.x, transform.position.y, newMovevment.z - ClickToMove.Instance.transform.position.y + 0.08f);
            transform.position = pos;
           

        
        
    }
}
