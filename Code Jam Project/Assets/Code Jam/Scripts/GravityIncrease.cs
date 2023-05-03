using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityIncrease : MonoBehaviour
{
    [SerializeField] Vector3 newGravity;

    private void Start()
    {
        Physics.gravity = newGravity;
    }
}
