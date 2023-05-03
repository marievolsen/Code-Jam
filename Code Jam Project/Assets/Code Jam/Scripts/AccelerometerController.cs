using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerController : MonoBehaviour
{
    //Based on "BoxScript" and "Respawn", made by Victor Hejø during HTX at ZBC Ringsted.
    //Based on the comment section of https://www.youtube.com/watch?v=fsEkZLBeTJ8

    [SerializeField] private float speed;
    private Rigidbody rb;
    [SerializeField] private int yValue;
    public static Vector3 spawnposition;
    [SerializeField] private Vector3 startPosition;
    public bool checkpoint;
    public static int collectibleCount;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (checkpoint)
        {
            spawnposition = startPosition;
        }
        transform.position = spawnposition;
    }

    void FixedUpdate()
    {
        Vector3 acc = Input.acceleration;
        rb.AddForce(acc.x * speed, yValue, acc.y * speed);
    }

    public void SetSpawnPosition(Vector3 position)
    {
        spawnposition = position;
    }
}
