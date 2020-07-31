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
    GameObject Player;



    public static ClickToMove Instance;
    private AIDestinationSetter aIDestinationSetter; 
    

    // Start is called before the first frame update
    void Start()
    {

        Player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        aIDestinationSetter = GetComponent<AIDestinationSetter>();  
        pause = true;
        aIDestinationSetter.target = null;
        DontDestroyOnLoad(this.gameObject);
        if (Instance == null)
        {
            Instance = this;


        }
        else
        {
            Destroy(gameObject);
        }
       

    }
    



    //DestinationSetter.target is getting the value of the hole position
    public void SetTargetPosition(Transform position)
    {



         //SheepVoice when we click to go to a hole,it chooses on random
            int num = Random.Range(1, 5);
            if (num == 1 )
            {
                AudioManager.instance.Play("SheepSound1");
            }
            else if (num == 2 )
            {
                AudioManager.instance.Play("SheepSound2");
            }
            else if (num == 3 )
            {
                AudioManager.instance.Play("SheepSound3");
            }
            else if (num == 4 )
            {
                AudioManager.instance.Play("SheepSound4");
            }
        
        if (pause)
        {
            
            Player.GetComponent<AIDestinationSetter>().target = position;
           

        }

    }


   public void StopSheep()
    {
        if(Player!=null)
        Player.GetComponent<AIDestinationSetter>().target = transform;
    }

}