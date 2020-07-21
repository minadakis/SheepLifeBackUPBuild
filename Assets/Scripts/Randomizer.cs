using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
   public List<Vector3> SpawnPos = new List<Vector3>();
  public  List<GameObject> Holes = new List<GameObject>();
    public List<float> ylist = new List<float>();
   List<Vector3> UsedPos = new List<Vector3>();
    public List<HolesBehaviour> HoleBehaviourList = new List<HolesBehaviour>();
    public int maxHoles = 1;
    private GameObject obj;
    private GameObject cosm;
    public int maxCosmetics = 1;
    public int maxObstacles = 1;
    public static Randomizer instance;

  public  int currentMain = 0;
  public   int currentSecondary = 0;
  public  int currentThird = 0;
    public int currentQuad = 0;

    public float ratioMainHole;
    public float ratioSecondHole;
    public float ratioThirdHole;
    public float ratioQuadHole;
    public GameObject HoleMain;
    public GameObject HoleSecond;
    public GameObject HoleThird;
    public GameObject HoleQuad;
    public GameObject Cosmetics;
    public GameObject Obstacles;
    public GameObject AstarPath;

    public GameObject blackhole;
    public GameObject redhole;
    public GameObject greenhole;
    public GameObject yellowhole;
    GameMaster gamemaster;
    




    
    //private void CreateGrid()
    //{
    //    for (int x = 4; x <= 16; x = x + 3)
    //    {
    //        for (float y = -2; y >= -9; y = y - 2)
    //        {
    //            Vector3 position = new Vector3(x, y, -1);

    //            SpawnPos.Add(position);
    //        }
    //    }
    //}

    private void CreateGrid()
    {
      
        for (int x = 0; x <= 16; x = x + 4)
        {
            for (float y = -2; y >= -6; y = y - 2)
            {
                Vector3 position = new Vector3(x, y, -1);

                SpawnPos.Add(position);
            }
        }
    }



    //Picking some object spawns from the list and checking so we dont get the same spawn from the list
    //Doing the same for the obstacles spawn

    private void GetRandomPos(int maxObjects,List<Vector3> list )
    {
        list.Clear();
        int currentObjects = 0;
        while (currentObjects < maxObjects)
        {
            int x = Random.Range(0,SpawnPos.Count);
            if (!list.Contains(SpawnPos[x]))
            {
                list.Add(SpawnPos[x]);
                currentObjects++;
            }
        }

    }

    

    //Creating the main,secondary,third holes depending the ratio spawn we want
    private void CreateHole()
    {
        
        foreach(Vector3 pos in UsedPos)
        {
            if (currentMain < Mathf.RoundToInt(maxHoles * ratioMainHole))
            {
               GameObject hole= Instantiate(HoleMain, pos, Quaternion.identity, transform);
                currentMain++;
                SpawnPos.Remove(pos);
                hole.GetComponent<HolesBehaviour>().correct = true;
                HoleBehaviourList.Add(hole.GetComponent<HolesBehaviour>());
                Vector3 temp = hole.transform.position;
                temp.z = temp.y * 0.1f;
                hole.transform.position = temp;

            }

            else if (currentSecondary < Mathf.RoundToInt(maxHoles * ratioSecondHole))
            {
                GameObject hole1 = Instantiate(HoleSecond, pos, Quaternion.identity, transform);
                currentSecondary++;
                SpawnPos.Remove(pos);
                hole1.GetComponent<HolesBehaviour>().correct = false;
                HoleBehaviourList.Add(hole1.GetComponent<HolesBehaviour>());
                Vector3 temp = hole1.transform.position;
                temp.z = temp.y * 0.1f;
                hole1.transform.position = temp;
            }
            else if ((currentThird < Mathf.RoundToInt(maxHoles * ratioThirdHole)) &&(HoleThird != null) )
            {
                GameObject hole2 = Instantiate(HoleThird, pos, Quaternion.identity, transform);
                currentThird++;
                SpawnPos.Remove(pos);
                hole2.GetComponent<HolesBehaviour>().correct = false;
                HoleBehaviourList.Add(hole2.GetComponent<HolesBehaviour>());
                Vector3 temp = hole2.transform.position;
                temp.z = temp.y * 0.1f;
                hole2.transform.position = temp;
            }
            else if ((currentQuad < Mathf.RoundToInt(maxHoles * ratioQuadHole) ) && (HoleQuad !=null))
            {
                GameObject hole3 = Instantiate(HoleThird, pos, Quaternion.identity, transform);
                currentQuad++;
                SpawnPos.Remove(pos);
                hole3.GetComponent<HolesBehaviour>().correct = false;
                HoleBehaviourList.Add(hole3.GetComponent<HolesBehaviour>());
                Vector3 temp = hole3.transform.position;
                temp.z = temp.y * 0.1f;




                hole3.transform.position = temp;
            }


        }
    }

   
    //In this method we create the obstacles into the map
    private void CreateObstacles(GameObject wantedObj,List<Vector3> objList)
    {
       
        foreach (Vector3 pos in objList)
        {
                       
           GameObject clone= Instantiate(wantedObj, pos, Quaternion.identity, transform);
            SpawnPos.Remove(pos);
            Vector3 temp = clone.transform.position;
            temp.z = temp.y * 0.1f;
            clone.transform.position = temp;

        };
        

       
    }

    // Start is called before the first frame update
    //Running all the functions
    void Start()
    {


        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        GameMaster.instance.StartLevel();
       
        
        
        CreateGrid();
        SelectRandomHole();

        GetRandomPos(maxHoles,UsedPos);
        CreateHole();  

        GetRandomPos(maxCosmetics,UsedPos);
        CreateObstacles(Cosmetics, UsedPos);

        GetRandomPos(maxObstacles,UsedPos);
        CreateObstacles(Obstacles,UsedPos);

        AstarPathFinding();

        GameMaster.instance.ShowTheColor(HoleMain.GetComponent<SpriteRenderer>().sprite, HoleMain.GetComponent<SpriteRenderer>().color);
       // Invoke("", 4F);

    }

    //A way to to change our main,second,third,quad hole every time we start the game
    //If we are on easy,we will take only 2 holes,on medium 3 holes,and on hard 4 holes
    private void SelectRandomHole() {
        if (Holes.Count == 4 || Holes.Count == 2)
        {
            int x = Random.Range(0, Holes.Count);
            HoleMain = Holes[x];
            Holes.Remove(Holes[x]);

            x = Random.Range(0, Holes.Count);
            HoleSecond = Holes[x];
            Holes.Remove(Holes[x]);

            if (Holes.Count == 2)
            {
                x = Random.Range(0, Holes.Count);
                HoleThird = Holes[x];
                Holes.Remove(Holes[x]);
            }


            if (Holes.Count == 1)
            {
                x = Random.Range(0, Holes.Count);
                HoleQuad = Holes[x];
                Holes.Remove(Holes[x]);
            }
        }

        if (Holes.Count == 3)
        {
            int x = Random.Range(0, Holes.Count);
            HoleMain = Holes[x];
            Holes.Remove(Holes[x]);

            x = Random.Range(0, Holes.Count);
            HoleSecond = Holes[x];
            Holes.Remove(Holes[x]);
         

            if (Holes.Count == 1)
            {
                x = Random.Range(0, Holes.Count);
                HoleThird = Holes[x];
                Holes.Remove(Holes[x]);
            }
        }
        
        
         
    }

    //We are scanning the grid for obstacles,every time we generate a new map
    public void AstarPathFinding()
    {
        AstarPath.GetComponent<AstarPath>().Scan() ;
        
    }


    
   

}
