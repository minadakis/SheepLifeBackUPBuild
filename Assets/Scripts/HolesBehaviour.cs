using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HolesBehaviour : MonoBehaviour
{
    public GameObject canvasButton1;
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

    public GameObject Player;
    public GameObject Shepard;
     GameObject Trans;

    private ParticleSystem dust;



    // Start is called before the first frame update
    //On start of each hole we disable the dig button
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
       // canvasButton1.SetActive(false);
        anim = GetComponent<Animator>();


    }


    public void OnTriggerEnter2D(Collider2D collider)
    {
       // Debug.Log(collider.name);
        if (collider.CompareTag("Player") && SelectedHole  )
        {
            
            anim.SetBool("CanMove", true);
            PlayerAnim = Player.GetComponent<Animator>();
            PlayerAnim.SetTrigger("iseating");
            
            


        }

        if (collider.CompareTag("Eating"))
        {

           

            if (GetComponent<HolesBehaviour>().correct == true)
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

            else if (GetComponent<HolesBehaviour>().correct == false)
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
  

    
    //When player get out of the hole collider,we disable again the dig button
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

    //On mouseup we send the hole transform to ClickToMove class.
    private void OnMouseUp()
    {
        
        
            ClickToMove.Instance.SetTargetPosition(transform);
        foreach (HolesBehaviour hole in Randomizer.instance.HoleBehaviourList)
        {
            hole.SelectedHole = false;

        }
        SelectedHole = true;
       


    }

    public void LevelManager()
    {
        if (Player.GetComponent<Winning>().CorrectHoles == Mathf.RoundToInt(Holes.GetComponent<Randomizer>().maxHoles * Holes.GetComponent<Randomizer>().ratioMainHole))
        {

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
        Player.GetComponent<AIPath>().enabled = true;
       
        SceneManager.LoadScene("Pathfinding");

    }

    

    public void GiveTimeToEat()
    {
        Debug.Log("Eating");
    }



    //The way we change the sprite of the pressed hole
    public void ChangeHoleSprite(bool correctBush)
    {
        if (correctBush)
        {
            GetComponent<SpriteRenderer>().sprite = holeSprite;
            transform.GetComponent<SpriteRenderer>().sprite = holeSprite;  //eixe ena child(0);
            
        }
        else
        {
            //
            //
        }
    }

   


}
