using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameStarted;


    //Set The Bool to Game Started State.
    public void StartGame()
    {

        isGameStarted = true;
    }


    //End The Game 
    public void Endgame()
    {
        //Now Just Reload The Main Scene So The We Can Restart.

        SceneManager.LoadScene(0);
    }

    //here We Will Start The Game if User Pressed Enter Key OR S From Keyboard.
    private void Update()
    {
        //if Enter Or S Key Is PRessed.
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.S))
        {

            //Start The Game 
            StartGame();

        }
        
    }
}
