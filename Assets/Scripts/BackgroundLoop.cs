using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{

    //Static Instance of The Loop Script.
    public static BackgroundLoop instance;


    private void Awake()
    {
        //if the instanec is Null Then Assign this Instance Class To The Instance Static object elese Just Destroy the 
        //Current gameObject instance. to get ride of Mutiple Instance of This Script Game Object. // (Just Keep The current Instance and Destroy All the other Ones).

        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        //below Method Is Used To Save Any Element Instanse on Reload
        //here GameObject is The Instance of Object on Which this Script is Added. which is Provide By MOniBehaviour Class By Default.
        DontDestroyOnLoad(gameObject);
    }


}
