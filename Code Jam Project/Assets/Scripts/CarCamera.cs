using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCamera : MonoBehaviour
{
    public float lerpTime = 3.5f;
    [Range(2, 3.5f)] public float forwardDistance = 3;
    private float accelerationEffect;

    private PlayerController controllerRef;
    private GameObject attachedVehicle;
    private int locationindicator = 1;

    private Vector3 newPos;
    private Transform target;
    private GameObject focusPoint;

    public float distance = 2;

    public Vector2[] cameraPos;

    private void Start()
    {
        cameraPos = new Vector2[4];
        cameraPos[0] = new Vector2(2, 0);
        cameraPos[1] = new Vector2(7.5f, 0.5f);
        cameraPos[2] = new Vector2(8.9f, 1.2f);

        attachedVehicle = GameObject.FindGameObjectWithTag("player");
        focusPoint = attachedVehicle.transform.Find("focus").gameObject;

        target = focusPoint.transform;
        controllerRef = attachedVehicle.GetComponent<PlayerController>();   
    }



    public void cycleCamera()
    {
        if (locationindicator >= cameraPos.Length - 1 || locationindicator < 0) locationindicator = 0;
        else locationindicator++;
    }

   
}
