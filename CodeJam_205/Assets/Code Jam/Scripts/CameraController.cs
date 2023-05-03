using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Based on "CameraFollower" made by Victor Hejø during HTX at ZBC Ringsted.

    public GameObject player;
    [SerializeField] private Vector3 offset;

    void Update()
    {
        transform.position = player.transform.position + offset;
        transform.LookAt(player.transform.position);
    }
}
