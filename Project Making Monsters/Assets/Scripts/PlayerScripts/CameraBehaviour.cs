// Add code to allow freeview if Ctrl pressed (PC only)


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls where the camera is in relation to the player
/// </summary>
public class CameraBehaviour : MonoBehaviour {
	public GameObject m_target; // default: the player
	Vector3 m_cameraOffset;     // initial distance between player and camera

	void Start() {
		m_cameraOffset = m_target.transform.position - transform.position;
	}

	/// <summary>
	/// Changes camera's angle and position so that it is always following right behind the player
	/// </summary>
	private void LateUpdate() {
		float desiredCameraAngle = m_target.transform.eulerAngles.y;

		Quaternion cameraRotation = Quaternion.Euler(0, desiredCameraAngle, 0);
		transform.position = m_target.transform.position - (cameraRotation * m_cameraOffset);

		transform.LookAt(m_target.transform);
	}
}