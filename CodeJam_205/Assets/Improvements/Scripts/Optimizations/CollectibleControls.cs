using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectibleControls : MonoBehaviour
{
    //Based on "CollectibleScript" and "Respawn", made by Victor Hejø during HTX at ZBC Ringsted.
    [SerializeField] private GameObject player;
    [SerializeField] private int nextLevelIndex;
    public AudioClip _clip;
    [SerializeField] private int index;
    private SpawnPoint sp;
    private ScoreManager sm;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Checkpoint")
        {
            AccelerometerController.SetSpawnPosition(transform.position);
            Destroy(gameObject);
            AccelerometerController.checkpoint = true;
            //MODIFICATION (START)
            PlayerPrefs.SetString("Checkpoint", $"{AccelerometerController.checkpoint}");
            //MODIFICATION (END)
            sp = GameObject.Find($"SpawnPoint{index}").GetComponent<SpawnPoint>(); 
            sp.SetCollection(true);
        }

        if (gameObject.tag == "Collectible")
        {
            Destroy(gameObject);
            AccelerometerController.collectibleCount++;
            sp = GameObject.Find($"SpawnPoint{index}").GetComponent<SpawnPoint>();
            sp.SetCollection(true);
            sm.SetScoreText();

            //Based on https://www.youtube.com/watch?v=tEsuLTpz_DU
            SoundManager.Instance.PlaySound(_clip);                       
        }

        if (gameObject.tag == "Opponent")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if(gameObject.tag == "NextLevel")
        {
            SceneManager.LoadScene(nextLevelIndex);
        }
    }

    public void SetIndex(int input)
    {
        index = input;
    }
}
