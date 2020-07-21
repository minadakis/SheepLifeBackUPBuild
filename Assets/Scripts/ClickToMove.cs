using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ClickToMove : MonoBehaviour
{
    public ParticleSystem dust;
    private Animator animator;
    private Vector3 TargetPosition;
    public bool pause;
    public bool stopMoving;
    GameObject Player;
    private TitlesScript titleScript;


    public static ClickToMove Instance;
    private AIDestinationSetter aIDestinationSetter; 
    

    // Start is called before the first frame update
    void Start()
    {
        titleScript = GetComponentInChildren<TitlesScript>();
        Player = GameObject.FindGameObjectWithTag("Player");



        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        animator = GetComponent<Animator>();
        aIDestinationSetter = GetComponent<AIDestinationSetter>();  
        pause = true;
        aIDestinationSetter.target = null;
        



    }
    



    //DestinationSetter.target is getting the value of the hole position
    public void SetTargetPosition(Transform position)
    {

        if (pause)
        {
            
            Player.GetComponent<AIDestinationSetter>().target = position;
           

        }

    }

    //public void CreateDust()
    //{
    //    dust.Play();
    //}

}