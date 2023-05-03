using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSkift : MonoBehaviour
{
    [SerializeField] private int newLevel;
    
    public void LoadScene()
    {
        SceneManager.LoadScene(newLevel);
    }

}
