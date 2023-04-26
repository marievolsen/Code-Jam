using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectibleControls : MonoBehaviour
{
    //Based on "BoxScript" and "Respawn", made by Victor Hejø during HTX at ZBC Ringsted.
    [SerializeField] private GameObject player;

    public void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Checkpoint")
        {
            player.GetComponent<PlayerController>().SetSpawnPosition(transform.position);
            Destroy(gameObject);
            PlayerController.checkpointCount++;
        }

        if (gameObject.tag == "Collectible")
        {
            Destroy(gameObject);
            PlayerController.collectibleCount++;
        }

        if (gameObject.tag == "Opponent")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
