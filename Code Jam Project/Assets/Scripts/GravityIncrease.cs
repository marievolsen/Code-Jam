using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityIncrease : MonoBehaviour
{
    private void Start()
    {
        Physics.gravity = new Vector3(0, -80, 0);
    }
}
