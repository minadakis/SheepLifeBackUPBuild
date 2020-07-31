using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectRatio : MonoBehaviour
{
   
    void Start()
    {
        if (Camera.main.aspect >= 1.7)// 16:9
        {
            
            transform.GetComponent<Camera>().orthographicSize = 6.01F;
        }

        else if (Camera.main.aspect > 1.6)// 5:3
        {
            
            transform.GetComponent<Camera>().orthographicSize = 6.5F;
        }


        else if (Camera.main.aspect >=1.51 && Camera.main.aspect <=1.6)// 16:10
        {
            
            transform.GetComponent<Camera>().orthographicSize = 6.57F;
        }


        else if (Camera.main.aspect > 1.4 && Camera.main.aspect<1.5)// 3:2
        {
            
            transform.GetComponent<Camera>().orthographicSize = 6.55F;
        }


        else // 4:3
        {
            
            transform.GetComponent<Camera>().orthographicSize = 8.06F;
        }
         

    }


}
