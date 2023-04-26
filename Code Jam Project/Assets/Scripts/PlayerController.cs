using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Based on https://www.youtube.com/watch?v=jvwX5WthM2o. Copied from https://paste.myst.rs/j7rol335.
    //Based on "BoxScript" and "Respawn", made by Victor Hejø during HTX at ZBC Ringsted.

    //Spawning
    public static Vector3 spawnposition;
    [SerializeField] private Vector3 startPosition;
    public static int checkpointCount;
    public static int collectibleCount;

    //Movement
    [SerializeField] float speed = 3.3f;
    //private float rotspeed = 90f;
    private Vector3 moveDirection = Vector3.zero;
    [SerializeField] private CharacterController controller;

    //Rotation
    private float _initialYAngle = 0f;
    private float _appliedGyroYAngle = 0f;
    private float _calibrationYAngle = 0f;
    private Transform _rawGyroRotation;
    private float _tempSmoothing;

    //settings
    private float _smoothing = 0.1f;

    private void Update()
    {
        //Movement
        Vector3 move = new Vector3 (Input.acceleration.x * speed * Time.deltaTime, 0f, -Input.acceleration.z * speed * Time.deltaTime);
        Vector3 rotMovement = transform.TransformDirection(move);
        controller.Move(rotMovement);

        //Rotation
        ApplyGyroRotation();
        ApplyCalibration();
        transform.rotation = Quaternion.Slerp(transform.rotation, _rawGyroRotation.rotation, _smoothing);

    }

    private IEnumerator Start()
    {
        if (checkpointCount == 0)
        {
            spawnposition = startPosition;
        }
        transform.position = spawnposition;

        Input.gyro.enabled = true;
        Application.targetFrameRate = 60;
        _initialYAngle = transform.eulerAngles.y;

        _rawGyroRotation = new GameObject("GyroRaw").transform;
        _rawGyroRotation.position = transform.position;
        _rawGyroRotation.rotation = transform.rotation;
        yield return new WaitForSeconds(1f);
        StartCoroutine(CalibrateYAngle());
    }

    private IEnumerator CalibrateYAngle()
    {
        _tempSmoothing = _smoothing;
        _smoothing = 1f;
        _calibrationYAngle = _appliedGyroYAngle - _initialYAngle;
        yield return null;
        _smoothing = _tempSmoothing;
    }

    private void ApplyGyroRotation()
    {
        _rawGyroRotation.rotation = Input.gyro.attitude;
        _rawGyroRotation.Rotate(0f, 0f, 180f, Space.Self);
        _rawGyroRotation.Rotate(90f, 180f, 0f, Space.World);
        _appliedGyroYAngle = _rawGyroRotation.eulerAngles.y;
    }

    private void ApplyCalibration()
    {
        _rawGyroRotation.Rotate(0f, -_calibrationYAngle, 0f, Space.World);
    }

    public void SetEnabled(bool value)
    {
        enabled = true;
        StartCoroutine(CalibrateYAngle());
    }

    //Based on "BoxScript" and "Respawn", made by Victor Hejø during HTX at ZBC Ringsted.
    public void SetSpawnPosition(Vector3 position)
    {
        spawnposition = position;
    }
}
