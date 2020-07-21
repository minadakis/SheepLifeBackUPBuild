using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CustomConsole : MonoBehaviour
{
    public TMP_Text console_text;
    public TMP_Text sheep_Transform;


    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player")!=null)
        sheep_Transform.text = GameObject.FindGameObjectWithTag("Player").transform.position.z.ToString();
    }
}
