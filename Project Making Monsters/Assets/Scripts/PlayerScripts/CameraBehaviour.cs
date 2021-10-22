// Add code to allow freeview if Ctrl pressed (PC only)


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Controls where the camera is in relation to the player
/// </summary>
public class CameraBehaviour : MonoBehaviour {
	public GameObject target;	// default: the player
	Vector3 cameraOffset;		// Initial distance between player and camera

	void Start() {
		cameraOffset = target.transform.position - transform.position;
	}

	void Update() {

	}

	/// <summary>
	/// Changes camera's angle and position so that it is always following right behind the player
	/// </summary>
	private void LateUpdate() {
		float desiredCameraAngle = target.transform.eulerAngles.y;

		Quaternion cameraRotation = Quaternion.Euler(0, desiredCameraAngle, 0);
		transform.position = target.transform.position - (cameraRotation * cameraOffset);

		transform.LookAt(target.transform);
	}
}