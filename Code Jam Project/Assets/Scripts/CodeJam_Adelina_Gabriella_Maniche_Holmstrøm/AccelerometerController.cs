using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody))]
public class AccelerometerController : MonoBehaviour
{
    //Based on "BoxScript" and "Respawn", made by Victor Hejø during HTX at ZBC Ringsted.
    //Based on https://github.com/Kuurde/Roll-a-Ball / https://learn.unity.com/project/roll-a-ball

    [SerializeField] private float speed; // A variable to set the speed of the player
    private Rigidbody rb; //Setting the component of the gameobjects rigidbody ot a variable in order to manipulate its physics
    [SerializeField] private int yValue; //A variable that accounts for the three different values Vector 3 needs
    public static Vector3 spawnposition; // A static Vector3 that sets the spawnposition of the player
    [SerializeField] private Vector3 startPosition; // A Vector3 variable that set the start position of the 
    public static int checkpointCount; // a statifc counter for the checkpoints
    public static int collectibleCount; // a static counter for the collectibles 


    void Start()
    {

        rb = GetComponent<Rigidbody>(); // get the component of th eobects this script is assinged to's rigid body. 


        // this if statement sets the players transform position to the set start position if they fall out of bounds.
        if (checkpointCount == 0)
        {
            spawnposition = startPosition;
        }
        transform.position = spawnposition;

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.acceleration.x; // set the acceleration input from the x axis to a float called moveHorizontal
        float moveVertical = Input.acceleration.y; // set the acceleration input from the y axis to a float called moveVertical


        Vector3 movement = new Vector3(moveHorizontal, yValue, moveVertical); // Assign a Vector3 called movement to the float variable of
                                                                              // the three float vairbales of the axis x, y, and z.

        movement.Normalize(); // Nomralizes the new Vector3 to have a magnitude of 1

        rb.AddForce(movement * speed); //Adds the input of the movement vector as a force
                                       //times the set speed to the rigidbody of the gameobject
    }

    // a method that sets the spawn position using a Vector3 parameter to acces the position transform of the gameobject
    public void SetSpawnPosition(Vector3 position)
    {
        spawnposition = position;
    }

    private void Update()
    {
        //this if statement checks and makes sure the the orientation of the phone is set to landscapemode,
        //in order to move the player along the axis in the correct way.
        if(Input.deviceOrientation == DeviceOrientation.LandscapeLeft)
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }
        else if (Input.deviceOrientation == DeviceOrientation.LandscapeRight)
        {
            Screen.orientation = ScreenOrientation.LandscapeRight;
        }
    }
}
