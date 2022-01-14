// Add code to allow freeview if Ctrl pressed (PC only)


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls where the camera is in relation to the player
/// </summary>
public class CameraBehaviour : MonoBehaviour
{
    private GameObject _target; // default: the player

    Vector3 cameraOffset;       // initial distance between player and camera

    private void Awake()
    {
        _target = GameObject.FindGameObjectWithTag("Player");
    }

    /// <summary>
    /// Sets cameraOffset to follow player
    /// </summary>
    void Start()
    {
        cameraOffset = _target.transform.position - transform.position;
    }

    /// <summary>
    /// Changes camera's angle and position so that it is always following right behind the player
    /// </summary>
    private void LateUpdate()
    {
        float desiredCameraAngle = _target.transform.eulerAngles.y;

        Quaternion cameraRotation = Quaternion.Euler(0, desiredCameraAngle, 0);
        transform.position = _target.transform.position - (cameraRotation * cameraOffset);

        transform.LookAt(_target.transform);
    }
}
