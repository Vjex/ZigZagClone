using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {

    //This Var is For The target Position that is to be followed by the Camera.
    public Transform target;

    //This Varible is for Teh Difference of Position between our Main Camera And The target/Player that is to Followe 
    private Vector3 offset;


    //Using Awake method because Its Called When The The Scripta instance is created .

    // Use this for initialization
    void Awake () {
        //getting the Offset By The (Current Camera position - Current target Position).

        offset = transform.position - target.position;
	}

    private void LateUpdate()
    {
        //Now This Special Method Is Mainly Used For Camera Mainly Which is Called Automatically After The WHole Frame Executes if Any Position is Cahnged in Screen/View.

        transform.position = target.position + offset;
    }

}
