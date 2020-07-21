using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HolesBehaviourTutorial : MonoBehaviour
{
    //public GameObject canvasButton1;
    public int colorCode;
    public bool correct;
    private TitlesScript titleScript; //sos
    private Animator anim;
    private Animator shepard;
    public bool usedHole = false;
    public bool removeCollider = false;
    public ParticleSystem leafPartS;
    public Sprite holeSprite;
    GameObject Holes;
    public bool SelectedHole = false;
    public bool HoleIsReached = false;
    Animator transition;
    Animator PlayerAnim;
    public Animator lightOffAnimator;
    private bool phase2 = false;
    

    public GameObject Player;
    public GameObject Shepard;
    GameObject Trans;

    private ParticleSystem dust;


     void Start()
    {
        
        dust = GetComponent<ParticleSystem>();
        //Trans.GetComponent<Animator>();
        Trans = GameObject.Find("Transition");  //SOOS
        Trans.GetComponent<Animator>();
        Trans.GetComponent<Animator>().SetTrigger("StartTransition");      
        Player = GameObject.FindGameObjectWithTag("Player");
        Shepard = GameObject.FindGameObjectWithTag("Shepard");
        PlayerAnim = Player.GetComponent<Animator>();
        titleScript = GetComponentInChildren<TitlesScript>(); //sos
        Holes = GameObject.FindGameObjectWithTag("Holes");
        //canvasButton1.SetActive(false);
        anim = GetComponent<Animator>();

        
        


    }

    public void Update()
    {
        if (Player.GetComponent<Winning>().CorrectHoles == 1)
        {
            lightOffAnimator.SetBool("SecondPhase", true);
        }

        if (GameMaster.instance.instrunctionTutorial == true & Player.GetComponent<Winning>().CorrectHoles == 2)
        {

            Player.GetComponent<AIPath>().enabled = false;
            GameMaster.instance.instrunctionTutorial = false;

            Invoke("GoToMenu", 2f);
        }
        else if (GameMaster.instance.instrunctionTutorial == false & Player.GetComponent<Winning>().CorrectHoles == 2)
        {
            GameMaster.instance.easy = true;
            Invoke("GoToEasy", 2f);
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.CompareTag("Player"))
        {
            
            anim.SetBool("CanMove", true);
            PlayerAnim = Player.GetComponent<Animator>();
            PlayerAnim.SetTrigger("iseating");



        }

        if (collider.CompareTag("Eating"))
        {
            


            if (GetComponent<HolesBehaviourTutorial>().correct == true)
            {
                
                shepard = Shepard.GetComponent<Animator>();
                shepard.SetTrigger("happyShepard");

                Player.GetComponent<Winning>().CorrectHoles++;
                anim.SetBool("CanMove", false);
                ChangeHoleSprite(true);
                usedHole = true;
                GetComponent<Collider2D>().enabled = false;
                PlayerAnim.SetTrigger("CorrectEating");

                LevelManager();
            }

            else if (GetComponent<HolesBehaviourTutorial>().correct == false)
            {
                
                shepard = Shepard.GetComponent<Animator>();
                shepard.SetTrigger("madShepard");
                anim.SetBool("CanMove", false);
                GetComponent<Collider2D>().enabled = false;
                PlayerAnim.SetTrigger("FalseEating");
                ChangeHoleSprite(false);
                usedHole = true;


            }
            removeCollider = true;
        }

    }

    public void OnTriggerExit2D(Collider2D collider)
    {
       
       // canvasButton1.SetActive(false);
        if (collider.tag == "Player")
        {
            anim.SetBool("CanMove", false);
        }

        //MPOREI NA XREIAZETAI
        //if (titleScript.removeCollider && titleScript.usedHole==true)
        //{

        //    GetComponent<Collider2D>().enabled = false;



        //}




    }

    private void GoToMenu()
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        SceneManager.LoadScene("Menu");
    }

    private void GoToEasy()
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        SceneManager.LoadScene("Pathfinding");
    }

    private void OnMouseUp()
    {


       ClickToMove.Instance.SetTargetPosition(transform);
        lightOffAnimator.SetBool("GO", true);
        if (Player.GetComponent<Winning>().CorrectHoles == 1)
        {
            lightOffAnimator.SetBool("GO2", true);
        }

        //    foreach (HolesBehaviour hole in Randomizer.instance.HoleBehaviourList)
        //    {
        //        hole.SelectedHole = false;

        //    }
        //   SelectedHole = true;

        

    }

    public void LevelManager()
    {
        if (Player.GetComponent<Winning>().CorrectHoles == 2)
        {
           // SceneManager.LoadScene("Menu");
            StartCoroutine(Fade());


        }
    }

    IEnumerator Fade()
    {

        Trans.GetComponent<Animator>().SetTrigger("Transition");
        yield return new WaitForSeconds(2f);
        Player.GetComponent<AIPath>().enabled = false;
        Player.transform.position = new Vector3(-0.36f, -9f, 0f);
        Player.transform.localScale = new Vector3(1f, 1f, 1f);
        Player.GetComponent<AIDestinationSetter>().target = Player.transform;
       // Player.GetComponent<AIPath>().enabled = true;

       // SceneManager.LoadScene("Menu");

    }

    public void GiveTimeToEat()
    {
        Debug.Log("Eating");
    }

    public void ChangeHoleSprite(bool correctBush)
    {
        if (correctBush)
        {
            
            GetComponent<SpriteRenderer>().sprite = holeSprite;
            transform.GetComponent<SpriteRenderer>().sprite = holeSprite;  //eixe ena child(0);

        }
        else
        {
            
        }
    }

}
