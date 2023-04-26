using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerController : MonoBehaviour
{
    [SerializeField] float speed;


    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 acc = Input.acceleration;
        rb.AddForce(acc.x * speed, 0, acc.y * speed);
    }

    //Based on https://www.youtube.com/watch?v=fsEkZLBeTJ8
    /*public bool isFlat = true;
    private Rigidbody rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 tilt = Input.acceleration;

        if (isFlat)
        {
            tilt = Quaternion.Euler(90, 0, 0) * tilt;
        }

        rigid.AddForce(tilt);
    }*/
}
