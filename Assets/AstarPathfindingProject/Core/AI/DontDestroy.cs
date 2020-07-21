using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public static GameObject Path;
    // Start is called before the first frame update
    void Start()
    {
        if (Path==null){
            Path = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
     
    }   
}
