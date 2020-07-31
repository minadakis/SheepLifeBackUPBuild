using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    
    public bool easy = false;
    public bool medium = false;
    public bool hard=false;
    public bool selectedDifficulty;
    public bool instrunctionTutorial=false;
    GameObject Player;
    GameObject Holes;
    public GameObject blackhole;
    public GameObject redhole;
    public GameObject greenhole;
    public GameObject yellowhole;
    public GameObject grass;
    public GameObject hay;
    public GameObject hay_2;
    public Sprite hay03;
    public Sprite hay04;
    public Sprite grass1;


    public static GameMaster instance;

    GameObject correctColor;
    

    //We make this script instance so we dont want to destroy it after loading scenes
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

    //This update checks if we are on the last scene of the game,and if you press any key there you gonna open the main menu of the game
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
    //EASY=2 COLORS  MEDIUM=3 COLORS  HARD=6 DIFFERENT KIND OF BUSHES
    public void StartLevel()
    {
        Holes = GameObject.FindGameObjectWithTag("Holes");
        Player = GameObject.FindGameObjectWithTag("Player");
        Player.GetComponent<Winning>().CorrectHoles = 0;
        Player.GetComponent<Winning>().CurrentLevel++;

        Holes = GameObject.FindGameObjectWithTag("Holes");


        if (easy == true)
        {
           
            Holes.GetComponent<Randomizer>().Holes.Add(blackhole);
            Holes.GetComponent<Randomizer>().Holes.Add(yellowhole) ;
            
        }
        if (medium == true)
        {
          
            Holes.GetComponent<Randomizer>().Holes.Add(redhole);
            Holes.GetComponent<Randomizer>().Holes.Add(yellowhole);
            Holes.GetComponent<Randomizer>().Holes.Add(blackhole);

        }
        if (hard == true)
        {
            
            Holes.GetComponent<Randomizer>().Holes.Add(hay);
            Holes.GetComponent<Randomizer>().Holes.Add(grass);          
            Holes.GetComponent<Randomizer>().Holes.Add(yellowhole);
            Holes.GetComponent<Randomizer>().Holes.Add(redhole);
            Holes.GetComponent<Randomizer>().Holes.Add(hay_2);
            Holes.GetComponent<Randomizer>().Holes.Add(blackhole);
        }
       


        //We change the number of maxholes-cosmetics-maxObstacles depending the current level we are in

        if (Player.GetComponent<Winning>().CurrentLevel >= 0 && Player.GetComponent<Winning>().CurrentLevel < 3)
            {
            
                Holes.GetComponent<Randomizer>().maxHoles = 4;
                Holes.GetComponent<Randomizer>().maxCosmetics = 3;
                Holes.GetComponent<Randomizer>().maxObstacles = 3;

            }
            else if (Player.GetComponent<Winning>().CurrentLevel >= 3 && Player.GetComponent<Winning>().CurrentLevel < 6)
            {
             
                Holes.GetComponent<Randomizer>().maxHoles = 6;
                Holes.GetComponent<Randomizer>().maxCosmetics = 3;
                Holes.GetComponent<Randomizer>().maxObstacles = 3;

            }
            else if (Player.GetComponent<Winning>().CurrentLevel >= 6  && Player.GetComponent<Winning>().CurrentLevel<9)
            {
             
                Holes.GetComponent<Randomizer>().maxHoles = 8;
                Holes.GetComponent<Randomizer>().maxCosmetics = 3;
                Holes.GetComponent<Randomizer>().maxObstacles = 3;

            }

        //If we reach the lvl8,then we move from easy to medium and from medium to hard
        //If we are on hard and currentlevel 8 then we gonna open the last scene of the game which is the end of game scene
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
                    Player.GetComponent<Winning>().CurrentLevel = 0;
                    medium = true;
                    hard = false;

                }
                else if (medium == true)
                {
                    easy = false;
                    medium = false;
                    Player.GetComponent<Winning>().CurrentLevel = 0;
                    hard = true;

                }
                else if (hard == true)
                {
                    easy = false;
                    medium = false;
                    hard = false;
                    Player.GetComponent<Winning>().CurrentLevel = 0;
                    Destroy(GameObject.FindGameObjectWithTag("Player"));
                    SceneManager.LoadScene("EndOfGame");
                   
                }
            }
        }

       




    }
   
    //This is the image in starting bubble animation
    //Depending the image we wanna show,we scale it down or up to have a normal size inside the bubble animation
    public void ShowTheColor(Sprite sprite,Color SpriteColor)
    {
        Vector3 newScale = new Vector3(1.5f, 1.5f, 1.5f);
        Vector3 newScale2 = new Vector3(1f, 1f, 1f);
        Vector3 newScale3 = new Vector3(0.7f, 0.7f, 0.7f);
        correctColor = GameObject.FindGameObjectWithTag("CorrectColor");
        if (sprite == hay03)
        {
            correctColor.GetComponent<SpriteRenderer>().transform.localScale = newScale;
            correctColor.GetComponent<SpriteRenderer>().sprite = hay03;


       
        }
        else if (sprite == grass1)
        {

            correctColor.GetComponent<SpriteRenderer>().transform.localScale = newScale3;
            correctColor.GetComponent<SpriteRenderer>().sprite = grass1;



        }
        else if (sprite == hay04)
        {

            correctColor.GetComponent<SpriteRenderer>().transform.localScale = newScale;
            correctColor.GetComponent<SpriteRenderer>().sprite = hay04;

        }
        else
        {

            correctColor.GetComponent<SpriteRenderer>().transform.localScale = newScale2;
            correctColor.GetComponent<SpriteRenderer>().sprite = sprite;
        }
        

    }



}




