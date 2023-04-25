using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private Vector3 offset;

    void Update()
    {
        transform.position = player.transform.position + offset;
        transform.LookAt(player.transform.position);
    }
}
