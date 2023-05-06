using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectibleControls : MonoBehaviour
{
    //Based on "BoxScript" and "Respawn", made by Victor Hejø during HTX at ZBC Ringsted.
    [SerializeField] private GameObject player;
    [SerializeField] private int nextLevelIndex;
    public AudioClip _clip;

    public void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Checkpoint")
        {
            player.GetComponent<AccelerometerController>().SetSpawnPosition(transform.position); //If colliding with Checkpoint tag, sets playes spawn position to position of said checkpoint
            Destroy(gameObject); //Detroys object when colliding
            AccelerometerController.checkpointCount++; //Adds one count to checkpoint count
        }

        if (gameObject.tag == "Collectible")
        {
            Destroy(gameObject); //If colliding with tag Collectible, detroys gameobject
            AccelerometerController.collectibleCount++; //Adds one count to collectible count
            //SoundManager.Instance.PlaySound(_clip); //Plays collectible sound clip
            ScoreManager.control.AddPoint();
        }

        if (gameObject.tag == "Opponent")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //If colliding with opponent tag, restarts scene
        }

        if(gameObject.tag == "NextLevel")
        {
            SceneManager.LoadScene(nextLevelIndex); //If colliding with NextLevel tag, plays next level build index
        }


    }
}
