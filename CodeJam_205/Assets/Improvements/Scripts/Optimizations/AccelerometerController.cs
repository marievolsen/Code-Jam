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
        //MODIFICATION (START)
        if (PlayerPrefs.HasKey("Checkpoint"))
        {
            string s = PlayerPrefs.GetString("Checkpoint");
            if (s == "True")
            {
                checkpoint = true;
            }
        }
        //MODIFICATION (END)
        if (!checkpoint)
        {
            spawnPosition = startPosition;
        }
        else
        {
            if (PlayerPrefs.HasKey("SpawnPositionXYZ"))
            {
                string input = PlayerPrefs.GetString("SpawnPositionXYZ");
                string[] coordinates = input.Split(";");
                float.TryParse(coordinates[0], out spawnPosition.x);
                float.TryParse(coordinates[1], out spawnPosition.y);
                float.TryParse(coordinates[2], out spawnPosition.z);
            }
        }
        transform.position = spawnPosition;
    }

    void FixedUpdate()
    {
        Vector3 acc = Input.acceleration;
        rb.AddForce(acc.x * speed, yValue, acc.y * speed);
    }

    public static void SetSpawnPosition(Vector3 position)
    {
        spawnPosition = position;
        PlayerPrefs.SetString("SpawnPositionXYZ", $"{spawnPosition.x};{spawnPosition.y};{spawnPosition.z}");
    }

    public Vector3 GetStartPosition()
    {
        return startPosition;
    }
}
