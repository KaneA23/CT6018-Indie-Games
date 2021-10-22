// Fix gliding / second delay from when you release button


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Controls the player's controls
/// </summary>
public class PlayerBehaviour : MonoBehaviour {
	public float movementSpeed = 10;
	public float turningSpeed = 150;

	BuildingBehaviour building;
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
		if (vertical != 0) {
			//rb.velocity += movementSpeed * Time.deltaTime * vertical * transform.forward;
			rb.AddForce(movementSpeed * vertical * transform.forward);
		} else {
			rb.velocity = Vector3.zero;
		}
	}

	/// <summary>
	/// If the player is touching a building and attacks it, building will lose health
	/// </summary>
	/// <param name="collision">other game object that player touches</param>
	private void OnCollisionStay(Collision collision) {
		Debug.Log("Touching: " + collision.gameObject.name);
		if (Input.GetKeyDown(KeyCode.Space)) {
			if (collision.gameObject.CompareTag("Building")) {
				building = collision.gameObject.GetComponent<BuildingBehaviour>();
				building.TakeDamage(10);
			}
		}
	}
}