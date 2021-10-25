// Fix gliding / second delay from when you release button


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Controls the player's controls
/// </summary>
public class PlayerBehaviour : MonoBehaviour {
	public float m_movementSpeed = 100;
	public float m_turningSpeed = 150;
	public bool m_isPunching;

	BuildingBehaviour m_building;
	Rigidbody m_rb;

	void Start() {
		m_rb = GetComponent<Rigidbody>();
		m_isPunching = false;
	}

	void Update() {
		//
		if (Input.GetKeyDown(KeyCode.Space)) {
			m_isPunching = true;
			StartCoroutine(AttackRoutine());
		}
	}

	/// <summary>
	/// Allows for the player to be able to move the character
	/// </summary>
	private void FixedUpdate() {
		// Controls the turning of that character
		float horizontal = Input.GetAxis("Horizontal") * m_turningSpeed * Time.deltaTime;
		transform.Rotate(0, horizontal, 0);

		// Allows the player to move forwards and backwards, dependent on direction player is facing
		float vertical = Input.GetAxis("Vertical");
		if (vertical != 0) {
			//rb.velocity += movementSpeed * Time.deltaTime * vertical * transform.forward;
			m_rb.AddForce(m_movementSpeed * vertical * transform.forward);
		} else {
			m_rb.velocity = Vector3.zero;
		}
	}

	/// <summary>
	/// If the player is touching a building and attacks it, building will lose health
	/// </summary>
	/// <param name="collision">other game object that player touches</param>
	private void OnCollisionStay(Collision collision) {
		if (m_isPunching) {
			if (collision.gameObject.CompareTag("Building")) {
				m_building = collision.gameObject.GetComponent<BuildingBehaviour>();
				m_building.TakeDamage(10);
				m_isPunching = false;
			}
		}
	}

	/// <summary>
	/// Makes sure player isn't always punching
	/// </summary>
	/// <returns>When the next FixedUpdate is called, punch is made not active</returns>
	IEnumerator AttackRoutine() {
		yield return new WaitForFixedUpdate();
		m_isPunching = false;
	}
}