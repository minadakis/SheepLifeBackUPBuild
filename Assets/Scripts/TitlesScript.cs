using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Pathfinding;
public class TitlesScript : MonoBehaviour
{
    
    public GameObject holePressed;
    public GameObject AstarPath;
    public Sprite holeSprite;
    public GameObject disableHoleAfterDogLeaves;
    public bool usedHole = false;
    public bool removeCollider = false;
    public bool startDust;
    Animator anim;

    GameObject correctHolesCounter;

    GameObject Player;
    GameObject Holes;
    GameObject Holes1;

  

    public void Start()
    {
        
       Player = GameObject.FindGameObjectWithTag("Player");
       Holes = GameObject.FindGameObjectWithTag("Holes");
       
      
    }

   
    //If we hit the correct hole,we change the sprite of the hole,we increase the correholes and we disable the hole
    //If we hit the wrong hole,we change the sprite of the hole,and we disable the hole 
    void OnMouseUp()
    {
           
        //if (holePressed.GetComponent<HolesBehaviour>().correct == true)
        //{
        //    Player.GetComponent<Winning>().CorrectHoles++;
            
        //    StartCoroutine(SheepEating());
        //    StartCoroutine(Fade());
            
        //    StartCoroutine(BarkingHappy());
        //    usedHole = true;
        //    GetComponent<Collider2D>().enabled = false;
        //    //correctHolesCounter = GameObject.FindGameObjectWithTag("CorrectHoles");
        //    //correctHolesCounter.GetComponent<TMPro.TextMeshProUGUI>().text = (Player.GetComponent<Winning>().CorrectHoles).ToString();

        //    Invoke("LevelManager", 3f);

           

        //}

        //if (holePressed.GetComponent<HolesBehaviour>().correct == false)
        //{            
        //    GetComponent<Collider2D>().enabled = false;
        //    StartCoroutine(SheepEating());
        //    StartCoroutine(BarkingSad());

        //    usedHole = true;
           
        //}

        //removeCollider = true;


    }

    
    //When we hit all the correct holes,we teleport the dog to the top left corner of game
    //We reset the aidestination script
    //And we reload the scene
    //public void LevelManager()
    // {
    //    if (Player.GetComponent<Winning>().CorrectHoles == Mathf.RoundToInt(Holes.GetComponent<Randomizer>().maxHoles * Holes.GetComponent<Randomizer>().ratioMainHole))
    //   {


            
            
    //        Player.transform.position = new Vector3(1.5f, -8f, 0f);
    //        Player.GetComponent<AIPath>().enabled = false;
    //        Player.GetComponent<AIDestinationSetter>().target = Player.transform;
    //        Player.GetComponent<AIPath>().enabled = true;
           
    //        SceneManager.LoadScene("Pathfinding");
            
                              
    //    }
    //}

    //Coroutine to make the dog immobile until the digging animation ends
    //IEnumerator Fade()
    //{

    //    ClickToMove.Instance.pause = false;
    //    yield return new WaitForSeconds(0.1f);
    //    ClickToMove.Instance.pause = true;

    //}

    ////We start the digging sound,then we change the sprite to hole,and after we play the sound of happy puppy
    //IEnumerator BarkingHappy()
    //{

    //    FindObjectOfType<AudioManager>().Play("Dig");
    //    yield return new WaitForSeconds(1f);
    //    ChangeHoleSprite();
    //    yield return new WaitForSeconds(0.5f);
    //    FindObjectOfType<AudioManager>().Play("bark_happy");



    //}

    ////We start the digging sound,then we change the sprite to hole,and after we play the sound of sad puppy
    //IEnumerator BarkingSad()
    //{

    //    FindObjectOfType<AudioManager>().Play("Dig");
    //    yield return new WaitForSeconds(1f);
    //    ChangeHoleSprite();
    //    yield return new WaitForSeconds(0.5f);
    //    FindObjectOfType<AudioManager>().Play("bark_sad");



    //}

    ////The way we change the sprite of the pressed hole
    //public void ChangeHoleSprite()
    //{
        
    //    holePressed.GetComponent<SpriteRenderer>().sprite = holeSprite;
    //    holePressed.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
    //    holePressed.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
    //}

    //IEnumerator SheepEating()
    //{
    //    anim = Player.GetComponent<Animator>();
    //    anim.SetBool("iseating", true);
    //    yield return new WaitForSeconds(1f);
    //    anim.SetBool("iseating", false);




    //}


}
