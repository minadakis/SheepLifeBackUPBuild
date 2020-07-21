using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLevels : MonoBehaviour
{
    public static  PlayerLevels Instance;
    public int Level;
    GameObject Player;
    GameObject Holes;
    
    public GameObject blackhole;
    public GameObject redhole;
    public GameObject greenhole;

    //GameObject animation;
    //private Animation anim;
    


    GameMaster gamemaster;



    private void Start()
    {
        //animation = GameObject.FindGameObjectWithTag("BubbleAnim");
        //anim=animation.GetComponent<Animation>();
        //anim.Play();
        //animation = GetComponentsInChildren<Animator>();
       
        //Player = GameObject.FindGameObjectWithTag("Player");
        //Holes = GameObject.FindGameObjectWithTag("Holes");

        //If we are in the first level of our game we run the LevelManagment to create our map
        //if (Player.GetComponent<Winning>().CurrentLevel == 0)
        //{
        //    LevelManagement();
        //}
    }

    

    //When we reload the scene to go to next level we reset the correctholes to 0
    //We increase gamelevel for 1 and we run the levelManagment to create our map
    //private void OnLevelWasLoaded()
    //{


    //    //Player = GameObject.FindGameObjectWithTag("Player");
    //    //Holes = GameObject.FindGameObjectWithTag("Holes");

        

    //    //Player.GetComponent<Winning>().CurrentLevel++;
    //    //Player.GetComponent<Winning>().CorrectHoles = 0;
    //    //LevelManagement();
    //    //Debug.Log("Giati");

    //}

    //LevelManagment function is looking the currentlevel we are in and create the right map
    //public void LevelManagement()
    //{




    //    if (GameMaster.instance.easy == true)
    //    {
           
    //        if (Player.GetComponent<Winning>().CurrentLevel >= 0 && Player.GetComponent<Winning>().CurrentLevel < 3)
    //        {

    //            Debug.Log("Mphkame sto easy");

               


    //            Holes = GameObject.FindGameObjectWithTag("Holes");
    //            Holes.GetComponent<Randomizer>().Holes[0] = blackhole;
    //            Holes.GetComponent<Randomizer>().Holes[1] = greenhole;
    //            Holes.GetComponent<Randomizer>().Holes[2] = redhole;
    //            //Holes.GetComponent<Randomizer>().Holes[3] = blackhole;


    //            Holes.GetComponent<Randomizer>().maxHoles = 3;
    //            Holes.GetComponent<Randomizer>().maxCosmetics = 8;
    //            Holes.GetComponent<Randomizer>().maxObstacles = 5;

    //        }
    //        else if (Player.GetComponent<Winning>().CurrentLevel >= 3 && Player.GetComponent<Winning>().CurrentLevel < 6)
    //        {
    //            Debug.Log("ola sto mauro");
    //            Holes.GetComponent<Randomizer>().Holes[0] = blackhole;
    //            Holes.GetComponent<Randomizer>().Holes[1] = greenhole;
    //            Holes.GetComponent<Randomizer>().Holes[2] = redhole;

    //            Holes = GameObject.FindGameObjectWithTag("Holes");
    //            Holes.GetComponent<Randomizer>().maxHoles = 6;
    //            Holes.GetComponent<Randomizer>().maxCosmetics = 8;
    //            Holes.GetComponent<Randomizer>().maxObstacles = 5;

    //        }
    //        else if (Player.GetComponent<Winning>().CurrentLevel >= 6 && Player.GetComponent<Winning>().CurrentLevel < 12)
    //        {
    //            Holes.GetComponent<Randomizer>().Holes[0] = blackhole;
    //            Holes.GetComponent<Randomizer>().Holes[1] = greenhole;
    //            Holes.GetComponent<Randomizer>().Holes[2] = redhole;

    //            Holes = GameObject.FindGameObjectWithTag("Holes");
    //            Holes.GetComponent<Randomizer>().maxHoles = 10;
    //            Holes.GetComponent<Randomizer>().maxCosmetics = 3;
    //            Holes.GetComponent<Randomizer>().maxObstacles = 5;

    //        }
    //        else if (Player.GetComponent<Winning>().CurrentLevel == 12)
    //        {
    //            Debug.Log("To game teleiwse");
    //        }
    //    }


    //    if (GameMaster.instance.medium == true)
    //    {
    //        Debug.Log("Mphkame sto medium");
    //        if (Player.GetComponent<Winning>().CurrentLevel >= 0 && Player.GetComponent<Winning>().CurrentLevel < 3)
    //        {

    //            Holes = GameObject.FindGameObjectWithTag("Holes");
    //            Holes.GetComponent<Randomizer>().maxHoles = 3;
    //            Holes.GetComponent<Randomizer>().maxCosmetics = 8;
    //            Holes.GetComponent<Randomizer>().maxObstacles = 5;

    //        }
    //        else if (Player.GetComponent<Winning>().CurrentLevel >= 3 && Player.GetComponent<Winning>().CurrentLevel < 6)
    //        {

    //            Holes = GameObject.FindGameObjectWithTag("Holes");
    //            Holes.GetComponent<Randomizer>().maxHoles = 6;
    //            Holes.GetComponent<Randomizer>().maxCosmetics = 8;
    //            Holes.GetComponent<Randomizer>().maxObstacles = 5;

    //        }
    //        else if (Player.GetComponent<Winning>().CurrentLevel >= 6 && Player.GetComponent<Winning>().CurrentLevel < 12)
    //        {

    //            Holes = GameObject.FindGameObjectWithTag("Holes");
    //            Holes.GetComponent<Randomizer>().maxHoles = 10;
    //            Holes.GetComponent<Randomizer>().maxCosmetics = 3;
    //            Holes.GetComponent<Randomizer>().maxObstacles = 5;

    //        }
    //        else if (Player.GetComponent<Winning>().CurrentLevel == 12)
    //        {
    //            Debug.Log("To game teleiwse");
    //        }
    //    }

    //    if (GameMaster.instance.hard == true)
    //    {
    //        Debug.Log("Mphkame sto hard");
    //        if (Player.GetComponent<Winning>().CurrentLevel >= 0 && Player.GetComponent<Winning>().CurrentLevel < 3)
    //        {

    //            Holes = GameObject.FindGameObjectWithTag("Holes");
    //            Holes.GetComponent<Randomizer>().maxHoles = 3;
    //            Holes.GetComponent<Randomizer>().maxCosmetics = 8;
    //            Holes.GetComponent<Randomizer>().maxObstacles = 5;

    //        }
    //        else if (Player.GetComponent<Winning>().CurrentLevel >= 3 && Player.GetComponent<Winning>().CurrentLevel < 6)
    //        {

    //            Holes = GameObject.FindGameObjectWithTag("Holes");
    //            Holes.GetComponent<Randomizer>().maxHoles = 6;
    //            Holes.GetComponent<Randomizer>().maxCosmetics = 8;
    //            Holes.GetComponent<Randomizer>().maxObstacles = 5;

    //        }
    //        else if (Player.GetComponent<Winning>().CurrentLevel >= 6 && Player.GetComponent<Winning>().CurrentLevel < 12)
    //        {

    //            Holes = GameObject.FindGameObjectWithTag("Holes");
    //            Holes.GetComponent<Randomizer>().maxHoles = 10;
    //            Holes.GetComponent<Randomizer>().maxCosmetics = 3;
    //            Holes.GetComponent<Randomizer>().maxObstacles = 5;

    //        }
    //        else if (Player.GetComponent<Winning>().CurrentLevel == 12)
    //        {
    //            Debug.Log("To game teleiwse");
    //        }
    //    }





















    //    if (Player.GetComponent<Winning>().CurrentLevel >= 0 && Player.GetComponent<Winning>().CurrentLevel < 3)
    //    {
            
    //        Holes = GameObject.FindGameObjectWithTag("Holes");
    //        Holes.GetComponent<Randomizer>().maxHoles = 3;
    //        Holes.GetComponent<Randomizer>().maxCosmetics = 8;
    //        Holes.GetComponent<Randomizer>().maxObstacles = 5;

    //    }
    //    else if (Player.GetComponent<Winning>().CurrentLevel >= 3 && Player.GetComponent<Winning>().CurrentLevel < 6)
    //    {
            
    //        Holes = GameObject.FindGameObjectWithTag("Holes");
    //        Holes.GetComponent<Randomizer>().maxHoles = 6;
    //        Holes.GetComponent<Randomizer>().maxCosmetics = 8;
    //        Holes.GetComponent<Randomizer>().maxObstacles = 5;

    //    }
    //    else if (Player.GetComponent<Winning>().CurrentLevel >= 6 && Player.GetComponent<Winning>().CurrentLevel < 12)
    //    {
           
    //        Holes = GameObject.FindGameObjectWithTag("Holes");
    //        Holes.GetComponent<Randomizer>().maxHoles = 10;
    //        Holes.GetComponent<Randomizer>().maxCosmetics = 3;
    //        Holes.GetComponent<Randomizer>().maxObstacles = 5;

    //    }
    //    else if (Player.GetComponent<Winning>().CurrentLevel == 12)
    //    {
    //        Debug.Log("To game teleiwse");
    //    }


    }

