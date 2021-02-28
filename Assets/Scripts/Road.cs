using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{

    public GameObject roadprefab;

    public Vector3 lastPos;

    private float offset = 0.701f;

    //Road Count to get The Crystall Activated On Every Fifth Road Creation.
    private int roadCount=0;

    /*
    //create The new Roat By Calling The Creating Method Repetidly in Every 1 second.
    private void Awake()
    {
        InvokeRepeating("CreateNewRoadPart", 1f, 1);
    }
    */

    //create Repeatidly a New Road Part in every Half Second.
    public void StartBuilding()
    {
        InvokeRepeating("CreateNewRoadPart", 1f, 0.5f);
    }

    public void CreateNewRoadPart()
    {
        Debug.Log("Creating New Road Part");

        //This Will Be The Position of Our new Road Part. Which in Initially at (0,0,0).
        Vector3 spawnPos = Vector3.zero;


        //Getting a Random No Decide Which Direction To Create a Road Left or Right.
        float chance = Random.Range(0, 100);

        if(chance < 50) {
            //Right Direction To The Last Road Part Position.

            spawnPos = new Vector3(lastPos.x + offset, lastPos.y, lastPos.z + offset);
        }
        else
        {   
            //Left Direction To The Last Road Part Position.
            spawnPos = new Vector3(lastPos.x - offset, lastPos.y, lastPos.z + offset);
        }

        //Now Instatiate The New Road Part To The Desired Direction.
        GameObject g = Instantiate(roadprefab, spawnPos, Quaternion.Euler(0, 45, 0));

        //Now ReAssign the LastPostion of Road Part To the New Intanciated Road Part Postion.
        lastPos = g.transform.position;



        //Activating Crystall
        roadCount++;
        if(roadCount % 5 == 0)
        {
            //her GetChild(0) = 0 Means , The First Child Of The RoadPart Created.
            g.transform.GetChild(0).gameObject.SetActive(true);
        }
    }


 
}
