using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameratest : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;




    private void Update()
    {
       
        //if (GameObject.FindGameObjectWithTag("cameratest") != null&& GameObject.FindGameObjectWithTag("cameratestMain")!=null)
        //{
           

            if (Input.GetKeyDown(KeyCode.D))
            {
            camera1 = GameObject.FindGameObjectWithTag("cameratestMain").GetComponent<Camera>();
            camera2 = GameObject.FindGameObjectWithTag("cameratest").GetComponent<Camera>();

            Debug.Log("camera2");
                camera1.gameObject.SetActive(false);
                camera2.gameObject.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.V))
            {
            camera1 = GameObject.FindGameObjectWithTag("cameratestMain").GetComponent<Camera>();
            camera2 = GameObject.FindGameObjectWithTag("cameratest").GetComponent<Camera>();

            Debug.Log("camera1");
                camera1.gameObject.SetActive(true);
                camera2.gameObject.SetActive(false);
            }
       // }
    }
}
