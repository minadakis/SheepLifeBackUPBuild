using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Difficulty : MonoBehaviour
{
    GameMaster gamemaster;
    public void Easy()
    {
        
        GameMaster.instance.easy = true;
        GameMaster.instance.medium = false;
        GameMaster.instance.hard = false;
        SceneManager.LoadScene("Pathfinding");
        GameMaster.instance.selectedDifficulty = true;
        
    }

    public void Medium()
    {

        GameMaster.instance.medium = true;
        GameMaster.instance.easy = false;
        GameMaster.instance.hard = false;
        SceneManager.LoadScene("Pathfinding");
        GameMaster.instance.selectedDifficulty = true;
    }

    public void Hard()
    {
        GameMaster.instance.hard = true;
        GameMaster.instance.easy = false;
        GameMaster.instance.medium = false;
        SceneManager.LoadScene("Pathfinding");
        GameMaster.instance.selectedDifficulty = true;
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
        GameMaster.instance.hard = false;
        GameMaster.instance.easy = false;
        GameMaster.instance.medium = false;
        SceneManager.LoadScene("Tutorial");
        GameMaster.instance.selectedDifficulty = false;
    }

    public void InstrunctionsTutorial()
    {
        GameMaster.instance.hard = false;
        GameMaster.instance.easy = false;
        GameMaster.instance.medium = false;
        SceneManager.LoadScene("Tutorial");
        GameMaster.instance.selectedDifficulty = false;
        GameMaster.instance.instrunctionTutorial = true;
    }



}
