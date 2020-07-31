using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HolesBehaviourTutorial : MonoBehaviour
{

    public bool correct;
    private Animator anim;
    private Animator shepard;
    public bool usedHole = false;
    public bool removeCollider = false;
    public Sprite holeSprite;
    GameObject Holes;
    public bool SelectedHole = false;
    public bool HoleIsReached = false;
    Animator transition;
    Animator PlayerAnim;
    public Animator lightOffAnimator;
    public GameObject Player;
    public GameObject Shepard;
    GameObject Trans;
    private Vector3 scaleChange;
    private ParticleSystem dust;
    public BoxCollider2D boxCollider2D;


    void Start()
    {
        
        dust = GetComponent<ParticleSystem>();
        Trans = GameObject.Find("Transition");  
        Trans.GetComponent<Animator>();
        Trans.GetComponent<Animator>().SetTrigger("StartTransition");      
        Player = GameObject.FindGameObjectWithTag("Player");
        Shepard = GameObject.FindGameObjectWithTag("Shepard");
        PlayerAnim = Player.GetComponent<Animator>();
        Holes = GameObject.FindGameObjectWithTag("Holes");
        anim = GetComponent<Animator>();

    }

    //On this update if the sheep ate the first bush of the tutorial,then we start the second phase of the tutorial animation
    //If the sheep ate all the correct bushes and we are on the instrunction tutorial then we return to main menu
    // Otherwish we just start the game from the first level of easy difficulty
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

    //If bush collide with our player then the sheep can try to eat the bush
    //IF its the correct one the sheep is gonan eat it,otherwise not
    //Whatever happens we gonna remove the collider of that bush so player can not click it again
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

    
    public void EnableCollider()
    {
        if (boxCollider2D != null)
        {
            boxCollider2D.enabled = true;
        }
        
    }

    //When the player leave the bush we gonna stop the bush animation
    public void OnTriggerExit2D(Collider2D collider)
    {
       

        if (collider.tag == "Player")
        {
            anim.SetBool("CanMove", false);
        }


    }

    //Function to return  us to main menu
    private void GoToMenu()
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        SceneManager.LoadScene("Menu");
    }

    //Function to start the game from easy difficulty
    private void GoToEasy()
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        SceneManager.LoadScene("Pathfinding");
    }


    //If player click the first tutorial bush then our main animation is gonna move to next phase
    private void OnMouseUp()
    {

       ClickToMove.Instance.SetTargetPosition(transform);
        lightOffAnimator.SetBool("GO", true);
        if (Player.GetComponent<Winning>().CorrectHoles == 1)
        {
            lightOffAnimator.SetBool("GO2", true);
        }

    }

    //If sheep ate all the correct bushes then we will start the transition animation and move our player to his starting position
    public void LevelManager()
    {
        if (Player.GetComponent<Winning>().CorrectHoles == 2)
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

    }


    public void GiveTimeToEat()
    {
        Debug.Log("Eating");
    }

    //This function change the bush sprite to an eaten sprite,and makes the bush shadow to a smaller one and a little bit brighter
    public void ChangeHoleSprite(bool correctBush)
    {
        if (correctBush)
        {
            EnableCollider();
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
            currentScale = Vector3.Lerp(currentScale, scaleChange, Time.deltaTime * 2f);
            transform.Find("Shadow").GetComponent<Transform>().localScale = currentScale;
            yield return null;
        }
    }

    IEnumerator FadeShadowAlpha()
    {
        while (Mathf.Abs(transform.Find("Shadow").GetComponent<SpriteRenderer>().color.a - 0.1f) > 0.01f)
        {
            transform.Find("Shadow").GetComponent<SpriteRenderer>().color = Color.Lerp(transform.Find("Shadow").GetComponent<SpriteRenderer>().color, new Color(0, 0, 0, 0.1f), Time.deltaTime * 2);
            yield return null;
        }
    }


}
