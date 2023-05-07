using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectibleManager : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoints;

    public void ResetCollectibles()
    {
        AccelerometerController ac = GameObject.FindWithTag("Player").GetComponent<AccelerometerController>();
        AccelerometerController.SetSpawnPosition(ac.GetStartPosition());
        foreach (GameObject g in spawnPoints)
        {
            SpawnPoint sp = g.GetComponent<SpawnPoint>();
            sp.SetCollection(false);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}