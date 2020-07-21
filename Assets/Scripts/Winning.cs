using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Winning : MonoBehaviour
{

    public int CorrectHoles = 0;
    public int CurrentLevel ;
  
    public static GameObject instance;

    //We keep the dog in all scenes with dontdestroyonload
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
        {
            instance = this.gameObject;


        }else
       
        {
            Destroy(this.gameObject);

        }

        
    }

   
}
