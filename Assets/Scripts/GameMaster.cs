using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;
    public bool easy = false;
    public bool medium = false;
    public bool hard=false;
    public int stableDifficulty;
    public bool selectedDifficulty;
    public bool instrunctionTutorial=false;
    GameObject Player;
    GameObject Holes;

    public GameObject blackhole;
    public GameObject redhole;
    public GameObject greenhole;
    public GameObject yellowhole;
    public GameObject whiteflower;
    public GameObject redflower;
    public GameObject pinkflower;
    public GameObject grass;
    public GameObject hay;

    GameObject correctColor;
    


    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

       

    }

    public void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

       
        string sceneName = currentScene.name;

        if (sceneName == "EndOfGame" & Input.anyKey)
        {
            SceneManager.LoadScene("Menu");
        }

       
    }


    //Everytime the randomizer script is running,we execute this function
    //This func creates the map depending the difficulty mode we are playing
    //EASY=2 COLORS  MEDIUM=3 COLORS  HARD=4 COLORS
    public void StartLevel()
    {
        Holes = GameObject.FindGameObjectWithTag("Holes");
        Player = GameObject.FindGameObjectWithTag("Player");
        Player.GetComponent<Winning>().CorrectHoles = 0;
        Player.GetComponent<Winning>().CurrentLevel++;

        Holes = GameObject.FindGameObjectWithTag("Holes");


       

        


        if (easy == true)
        {
            Debug.Log("easy");
            Holes.GetComponent<Randomizer>().Holes.Add(blackhole);
            Holes.GetComponent<Randomizer>().Holes.Add(yellowhole) ;
            
        }
        if (medium == true)
        {
            Debug.Log("medium");
            Holes.GetComponent<Randomizer>().Holes.Add(redhole);
            Holes.GetComponent<Randomizer>().Holes.Add(yellowhole);
            Holes.GetComponent<Randomizer>().Holes.Add(blackhole);

        }
        if (hard == true)
        {
            Debug.Log("hard");
            Holes.GetComponent<Randomizer>().Holes.Add(hay);
            Holes.GetComponent<Randomizer>().Holes.Add(grass);          
            Holes.GetComponent<Randomizer>().Holes.Add(yellowhole);
            Holes.GetComponent<Randomizer>().Holes.Add(redhole); 
        }
       




        if (Player.GetComponent<Winning>().CurrentLevel >= 0 && Player.GetComponent<Winning>().CurrentLevel < 3)
            {
                Debug.Log(Player.GetComponent<Winning>().CurrentLevel);
                Holes.GetComponent<Randomizer>().maxHoles = 3;
                Holes.GetComponent<Randomizer>().maxCosmetics = 3;
                Holes.GetComponent<Randomizer>().maxObstacles = 3;

            }
            else if (Player.GetComponent<Winning>().CurrentLevel >= 3 && Player.GetComponent<Winning>().CurrentLevel < 6)
            {
                Debug.Log(Player.GetComponent<Winning>().CurrentLevel);
                Holes.GetComponent<Randomizer>().maxHoles = 5;
                Holes.GetComponent<Randomizer>().maxCosmetics = 3;
                Holes.GetComponent<Randomizer>().maxObstacles = 3;

            }
            else if (Player.GetComponent<Winning>().CurrentLevel >= 6  && Player.GetComponent<Winning>().CurrentLevel<9)
            {
                Debug.Log(Player.GetComponent<Winning>().CurrentLevel);
                Holes.GetComponent<Randomizer>().maxHoles = 6;
                Holes.GetComponent<Randomizer>().maxCosmetics = 3;
                Holes.GetComponent<Randomizer>().maxObstacles = 3;

            }

        if (Player.GetComponent<Winning>().CurrentLevel == 8)
        {
            if (selectedDifficulty)
            {
                Player.GetComponent<Winning>().CurrentLevel = 1;
            }
            else
            {
                if (easy == true)
                {
                    easy = false;
                    Debug.Log("Mphkame medium");
                    Player.GetComponent<Winning>().CurrentLevel = 0;
                    medium = true;
                    hard = false;

                }
                else if (medium == true)
                {
                    easy = false;
                    medium = false;
                    Debug.Log("Mphkame sto hard");
                    Player.GetComponent<Winning>().CurrentLevel = 0;
                    hard = true;

                }
                else if (hard == true)
                {
                    Debug.Log("telos");
                    easy = false;
                    medium = false;
                    hard = false;
                    Player.GetComponent<Winning>().CurrentLevel = 0;
                    Destroy(GameObject.FindGameObjectWithTag("Player"));
                    SceneManager.LoadScene("EndOfGame");
                   
                }
            }
        }

        //if (Player.GetComponent<Winning>().CurrentLevel == 2)
        //{
           
            
            
        //        if (easy == true)
        //        {
        //            easy = false;
        //            Debug.Log("Mphkame medium");
        //            Player.GetComponent<Winning>().CurrentLevel = 0;
        //            medium = true;
        //            hard = false;

        //        }
        //        else if (medium == true)
        //        {
        //            easy = false;
        //            medium = false;
        //            Debug.Log("Mphkame sto hard");
        //            Player.GetComponent<Winning>().CurrentLevel = 0;
        //            hard = true;

        //        }
        //        else if (hard == true)
        //        {
        //            easy = false;
        //            medium = false;
        //            hard = false;
        //            Player.GetComponent<Winning>().CurrentLevel = 0;
        //            SceneManager.LoadScene("EndOfGame");
        //        }

        //    if (selectedDifficulty)
        //    {
        //        Player.GetComponent<Winning>().CurrentLevel = 1;
        //    }
        //}




    }
   

    public void ShowTheColor(Sprite Sprite,Color SpriteColor)
    {
        correctColor = GameObject.FindGameObjectWithTag("CorrectColor");      
        correctColor.GetComponent<SpriteRenderer>().sprite = Sprite;
        correctColor.GetComponent<SpriteRenderer>().color = SpriteColor;

    }



}




