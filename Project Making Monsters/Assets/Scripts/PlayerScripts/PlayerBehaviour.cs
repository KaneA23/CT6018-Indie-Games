// Fix gliding / second delay from when you release button


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the player's controls
/// </summary>
public class PlayerBehaviour : MonoBehaviour {
	public float movementSpeed = 20;
	public float turningSpeed = 150;

	Rigidbody rb;


	void Start() {
		rb = GetComponent<Rigidbody>();
	}


	void Update() {

	}


	/// <summary>
	/// Allows for the player to be able to move the character
	/// </summary>
	private void FixedUpdate() {
		// Controls the turning of that character
		float horizontal = Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
		transform.Rotate(0, horizontal, 0);

		// Allows the player to move forwards and backwards, dependent on direction player is facing
		float vertical = Input.GetAxis("Vertical");
		if (vertical > 0) {
			rb.velocity += movementSpeed * Time.deltaTime * transform.forward;
		} else if (vertical < 0) {
			rb.velocity -= movementSpeed * Time.deltaTime * transform.forward;
		} //else {
		//	rb.velocity = 0 * transform.forward;
		//}
	}
}