using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AccelerometerController : MonoBehaviour
{
    //Based on "CollectibleScript" and "Respawn", made by Victor Hejø during HTX at ZBC Ringsted.
    //Based on the comment section of https://www.youtube.com/watch?v=fsEkZLBeTJ8

    [SerializeField] private float speed;
    private Rigidbody rb;
    [SerializeField] private int yValue;
    public static Vector3 spawnPosition;
    [SerializeField] private Vector3 startPosition;
    public static bool checkpoint;
    public static int collectibleCount;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (!checkpoint)
        {
            spawnPosition = startPosition;
        }
        //Commented out as it does not function properly at the moment.
        /*else
        {
            if (PlayerPrefs.HasKey("SpawnPositionXYZ"))
            {
                string input = PlayerPrefs.GetString("SpawnPositionXYZ");
                Debug.Log("GetString: " + input);
                string[] coordinates = input.Split(";");
                foreach (string s in coordinates) { Debug.Log(s); }
                float.TryParse(coordinates[0], out spawnPosition.x);
                float.TryParse(coordinates[1], out spawnPosition.y);
                float.TryParse(coordinates[2], out spawnPosition.z);
                Debug.Log(spawnPosition);
            }
        }*/
        transform.position = spawnPosition;
        Debug.Log(spawnPosition);
    }

    void FixedUpdate()
    {
        Vector3 acc = Input.acceleration;
        rb.AddForce(acc.x * speed, yValue, acc.y * speed);
    }

    public static void SetSpawnPosition(Vector3 position)
    {
        spawnPosition = position;

        //Commented out as it does not function properly at the moment.
        /*PlayerPrefs.SetString("SpawnPositionXYZ", $"{spawnPosition.x};{spawnPosition.y};{spawnPosition.z}");
        Debug.Log(PlayerPrefs.GetString("SpawnPositionXYZ"));
        Debug.Log(spawnPosition);*/
    }

    public Vector3 GetStartPosition()
    {
        return startPosition;
    }
}
