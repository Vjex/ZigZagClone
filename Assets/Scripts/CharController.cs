using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {

    //Get The Physics data OF The Player
    private Rigidbody rb;
    //Is Player Walking Right Direction
    private bool walkingRight = true;


    /// <summary>
    /// Animation Related Varibles
    /// </summary>
    public Transform rayStart;

    //Animator Varible Will Aimate/ controll the Player Animation.
    private Animator anim;



    //Game Manager Related Variables Start / Restart.
    private GameManager gamemanager;


	// Use this for initialization
	void Awake () {

        //Initialising Both RigidBody And The Animator varibles.

        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        gamemanager = FindObjectOfType<GameManager>();
	}

    private void FixedUpdate()
    {

        //Now Checking WHether The User Pressed The Space key To Start The GAme.
        //untill that Do not Change Player Position.
        if (!gamemanager.isGameStarted)
        {
            return;
        }
        else{

            //Start The Running Animation if Game Is Atarted.
            anim.SetTrigger("isRunning");
        }

        //Constantly Move Character Position.
        rb.transform.position = transform.position + transform.forward * 2 * Time.deltaTime;



       
    }


    // Update is called once per frame
    void Update () {
        if(Input.GetKeyDown(KeyCode.Space)){
            Switch();
        }

        //Checking For Player Needs To Change Jumb Animation/Fall Animation From Run or Not .
        //We Will Do this Through rayCast(Checking our Object Hitted Sommething in the asked Direction or not.

        RaycastHit hit;


        //So Here Each Argument Meaning :
        //1 : This is The Position of the Charachter/Player (Which is Here An Empty Object created inside the character with name RayStart)
        //2 : this Is The Checking For Hit Direction (i.e : '-' indicates opposte of 'UP' Direction Means Downward Directin.
        //3 : This the hit var Which Will Containt the hit related Details In Each Fram Which We Can Access To get the Hit Related Details.
        //4 : This is the fistane upto which the hit of any other object will be checked.

        //Logic here is If Not Hit Found Below The Player Means he started falling so Animate fall Animation
        if (!Physics.Raycast(rayStart.position, -transform.up, out hit , Mathf.Infinity)){
            //now Sett the Trigger Paramer which we have created inside our anim_comntroller for Going to Fall Animation State.

            Debug.Log("No Hit Found");
            anim.SetTrigger("isFalling");
        }


        //Now Stop The Game IF Player Falls .

        if(transform.position.y < -5)
        {
            gamemanager.Endgame();
        }


    }

    private void Switch(){

        walkingRight = !walkingRight;

        if (walkingRight)
            transform.rotation = Quaternion.Euler(0, 45, 0);
        else
            transform.rotation = Quaternion.Euler(0, -45, 0);

    }

}
