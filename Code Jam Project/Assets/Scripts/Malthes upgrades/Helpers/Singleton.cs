using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
//code based on https://www.youtube.com/watch?v=texonivDsy0&t=833s&ab_channel=BigfootCodes

// this makes it possible to use a singleton pattern for the panel manager. it works as a singleton that ensures that only one instance of the singleton pattern exist at one time. 
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // this declares a private static
    private static T _instance;

    // makes a public static that will return the private static
    public static T Instance
    {
        get
        {
            return _instance;
        }
    }
    //this will sett the _instance to an object, so it can only be called ones at a time. The scope is public and the awake method is called on load.
public void Awake()
{
    _instance = (T) (object) this;
}

}

