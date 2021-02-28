using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Boolean To Check Whether Game Started Or Not.
    public bool isGameStarted;
    public int score;
    public Text scoretext;
    public Text highScoretext;


    //Set the High Score Text On Awake
    private void Awake()
    {
        highScoretext.text = "Best : "+ GetHighScore().ToString();
    }



    //Set The Bool to Game Started State.
    public void StartGame()
    {

        isGameStarted = true;

        //Now Whenever Game Start , Start Creating new Road Parts.
        FindObjectOfType<Road>().StartBuilding();

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

    //Method to Increase The Score Of Player Whenever We Hit A Crystal/Collide To A Crystal.
    public void IncreaseScrore()
    {
        score++;

        //Set The New Score To The Score Text.
        scoretext.text = score.ToString();


        //Setting the High Score if Current Score Is Grater Than High Score.
        if(score > GetHighScore())
        {
            PlayerPrefs.SetInt("HighScore", score);

            //Now Aloso Change The Highest Score Text.
            highScoretext.text = "Best : " + score.ToString();
        }
    }

    // Method To get Teh Current Hogh Score Through Player Prefs Class.

    private int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore");
    }
}
