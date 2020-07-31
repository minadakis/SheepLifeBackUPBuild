using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HolesBehaviour : MonoBehaviour
{
     
    public bool correct;  
    private Animator anim;
    private Animator shepard;
    public bool usedHole = false;
    public bool removeCollider = false;
    public Sprite holeSprite;
    GameObject Holes;
    public bool SelectedHole = false;
    Animator transition;
    Animator PlayerAnim;
    public GameObject Player;
    public GameObject Shepard;
    GameObject Trans;

    private ParticleSystem dust;
    private GameObject shadow;
    private Vector3 scaleChange;

    //Awake is called before the start function
    public void Awake()
    {
        Trans = GameObject.Find("Transition");  //SOOS
        Trans.GetComponent<Animator>();
        Trans.GetComponent<Animator>().SetTrigger("StartTransition");
    }

    // Start is called before the first frame update
    void Start()
    {
        dust = GetComponent<ParticleSystem>();              
        Player = GameObject.FindGameObjectWithTag("Player");
        Shepard = GameObject.FindGameObjectWithTag("Shepard");
        PlayerAnim = Player.GetComponent<Animator>();
        Holes = GameObject.FindGameObjectWithTag("Holes");
        anim = GetComponent<Animator>();

    }


    //On trigger enter we check if the clicked bush collided with the player and we make the sheep to eat
    //If sheep is on a correct bush,it will eat it,otherwish it wont eat it
    //If sheep has ate all the correct bushes then we will call the levelmanager function which will remove the colliders of all other holes(so sheep cant go there after the end of level)
    //And then when the animations end we will move to the next scene
    public void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.CompareTag("Player") && SelectedHole  )
        {

           
            
            anim.SetBool("CanMove", true);
            PlayerAnim = Player.GetComponent<Animator>();
            PlayerAnim.SetTrigger("iseating");
            
            


        }

        if (collider.CompareTag("Eating"))
        {


            
            if (correct == true)
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
            else if (correct == false)
            {
               
                shepard = Shepard.GetComponent<Animator>();
                shepard.SetTrigger("madShepard");
                anim.SetBool("CanMove", false);
                GetComponent<Collider2D>().enabled = false;
                PlayerAnim.SetTrigger("FalseEating");
                ChangeHoleSprite(false);
                GetComponent<Collider2D>().enabled = false;
                usedHole = true;
                

            }
            removeCollider = true;
        }

    }
  

    
    //When bush collider is closed we will stop playing the bush animation
    public void OnTriggerExit2D(Collider2D collider)
    {
       
        if (collider.tag == "Player")
        {
            anim.SetBool("CanMove", false);
        }


    }

 
    //On mouseDonw we get the position of the bush clicked and we set this bush as selectedHole
    private void OnMouseDown()
    {
        
        
        ClickToMove.Instance.SetTargetPosition(transform);
        foreach (HolesBehaviour hole in Randomizer.instance.HoleBehaviourList)
        {
            hole.SelectedHole = false;

        }
        SelectedHole = true;
       


    }

    //LevelManager is called when sheep has ate all the correct bushes
    //We remove the colliders of the rest of bushes so sheep cant move to them at the end of each level
    //Then sheep is gonna make 2 jumps to the air,the scene transition will start,we gonna move our sheep to the starting position and finally we will change scene
    public void LevelManager()
    {
        if (Player.GetComponent<Winning>().CorrectHoles >= Mathf.RoundToInt(Holes.GetComponent<Randomizer>().maxHoles * Holes.GetComponent<Randomizer>().ratioMainHole))
        {
            //We close the colliders of other bushes so we cant click on them when we finish the level.
            BoxCollider2D[] allChildren = Holes.GetComponentsInChildren<BoxCollider2D>();
            foreach (BoxCollider2D child in allChildren)
            {              
                child.enabled = false;
            }
            StartCoroutine(Fade());


        }
    }



    IEnumerator Fade()
    {
        PlayerAnim.SetTrigger("HappyEnding");
        yield return new WaitForSeconds(1f);
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



    //If the bush we clicked is the correct one,then we will change the bush sprite to an eaten one
    //And we gonna scale down the shadow of the bush cause its eaten now
    public void ChangeHoleSprite(bool correctBush)
    {
        if (correctBush)
        {
            GetComponent<SpriteRenderer>().sprite = holeSprite;
            transform.GetComponent<SpriteRenderer>().sprite = holeSprite;  

            StartCoroutine(FadeShadowAlpha());
            StartCoroutine(FadeShadowScale());          


        }
       
    }

   IEnumerator FadeShadowScale()
    {

        scaleChange = new Vector3(2f, 1f, 1f);
        Vector3 currentScale = transform.Find("Shadow").GetComponent<Transform>().localScale;
        while (Vector3.Distance(transform.Find("Shadow").GetComponent<Transform>().localScale, scaleChange) > 0.1f)
        {
            currentScale = Vector3.Lerp(currentScale, scaleChange, Time.deltaTime*2f);
            transform.Find("Shadow").GetComponent<Transform>().localScale = currentScale;
            yield return null;
        }
    }

    IEnumerator FadeShadowAlpha()
    {
        while (Mathf.Abs(transform.Find("Shadow").GetComponent<SpriteRenderer>().color.a-0.1f) > 0.01f)
        {
           
            transform.Find("Shadow").GetComponent<SpriteRenderer>().color = Color.Lerp(transform.Find("Shadow").GetComponent<SpriteRenderer>().color, new Color(0, 0, 0, 0.1f), Time.deltaTime*2);
            yield return null;
        }
    }


}
