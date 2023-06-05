using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectibleManager : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject scoreManager;

    public void ResetCollectibles()
    {
        AccelerometerController ac = GameObject.FindWithTag("Player").GetComponent<AccelerometerController>();
        AccelerometerController.SetSpawnPosition(ac.GetStartPosition());
        foreach (GameObject g in spawnPoints)
        {
            SpawnPoint sp = g.GetComponent<SpawnPoint>();
            sp.SetCollection(false);
        }
        //MODIFICATION (START)
        ScoreManager sm = scoreManager.GetComponent<ScoreManager>();
        AccelerometerController.collectibleCount = 0;
        sm.SetScoreText();
        //MODIFICATION (END)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}