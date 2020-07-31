using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Difficulty : MonoBehaviour
{
    GameMaster gamemaster;
    public Animator playTransition;
    //Just a script where we start a different level or scene depending what the player choosed to play
    public void Easy()
    {

        StartCoroutine(DelayTransitionEasy());

    }

    public void Medium()
    {

        StartCoroutine(DelayTransitionMedium());
    }

    public void Hard()
    {
        StartCoroutine(DelayTransitionHard());
    }

    public void DefaultPlay()
    {
        
        GameMaster.instance.hard = false;
        GameMaster.instance.easy = true;
        GameMaster.instance.medium = false;
        SceneManager.LoadScene("Pathfinding");
        GameMaster.instance.selectedDifficulty = false;
        
    }

    public void Tutorial()
    {
        StartCoroutine(DelayTransitionPlay());
        
    }

    public void InstrunctionsTutorial()
    {
       
             StartCoroutine(DelayTransitionHardInstrunction());
    }

    IEnumerator DelayTransition()
    {
        
        playTransition.SetTrigger("Start");
        yield return new WaitForSeconds(2f);
        GameMaster.instance.hard = false;
        GameMaster.instance.easy = false;
        GameMaster.instance.medium = false;
        SceneManager.LoadScene("Tutorial");
        GameMaster.instance.selectedDifficulty = false;

    }

    IEnumerator DelayTransitionPlay()
    {
        
        playTransition.SetTrigger("Start");
        yield return new WaitForSeconds(2f);
        GameMaster.instance.hard = false;
        GameMaster.instance.easy = false;
        GameMaster.instance.medium = false;
        SceneManager.LoadScene("Tutorial");
        GameMaster.instance.selectedDifficulty = false;

    }

    IEnumerator DelayTransitionEasy()
    {
     
        playTransition.SetTrigger("Start");
        yield return new WaitForSeconds(2f);
        GameMaster.instance.easy = true;
        GameMaster.instance.medium = false;
        GameMaster.instance.hard = false;
        SceneManager.LoadScene("Pathfinding");
        GameMaster.instance.selectedDifficulty = true;

    }

    IEnumerator DelayTransitionMedium()
    {
        
        playTransition.SetTrigger("Start");
        yield return new WaitForSeconds(2f);
        GameMaster.instance.medium = true;
        GameMaster.instance.easy = false;
        GameMaster.instance.hard = false;
        SceneManager.LoadScene("Pathfinding");
        GameMaster.instance.selectedDifficulty = true;

    }

    IEnumerator DelayTransitionHard()
    {
        
        playTransition.SetTrigger("Start");
        yield return new WaitForSeconds(2f);
        GameMaster.instance.hard = true;
        GameMaster.instance.easy = false;
        GameMaster.instance.medium = false;
        SceneManager.LoadScene("Pathfinding");
        GameMaster.instance.selectedDifficulty = true;

    }

    IEnumerator DelayTransitionHardInstrunction()
    {
       
        playTransition.SetTrigger("Start");
        yield return new WaitForSeconds(2f);
        GameMaster.instance.hard = false;
        GameMaster.instance.easy = false;
        GameMaster.instance.medium = false;
        SceneManager.LoadScene("Tutorial");
        GameMaster.instance.selectedDifficulty = false;
        GameMaster.instance.instrunctionTutorial = true;

    }


}
