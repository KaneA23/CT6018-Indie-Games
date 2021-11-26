// Fix gliding / second delay from when you release button


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the player's controls
/// </summary>
public class PlayerBehaviour : MonoBehaviour {
	BuildingBehaviour m_building;
	Rigidbody m_rb;

	[Header("Movement")]
	float m_vertical, m_horizontal;
	public float m_movementSpeed = 100;
	public float m_turningSpeed = 150;

	[Header("Attacks")]
	public bool m_isPunching;
	public float m_attackStrength;

	private void Awake() {
		m_rb = GetComponent<Rigidbody>();
	}

	void Start() {
		m_isPunching = false;

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void Update() {
		PlayerInput();
	}

	/// <summary>
	/// Allows for the player to be able to move the character
	/// </summary>
	private void FixedUpdate() {
		Movement();
	}

	/// <summary>
	/// Assigns all variables to an input value
	/// </summary>
	private void PlayerInput() {
		m_horizontal = Input.GetAxisRaw("Horizontal");
		m_vertical = Input.GetAxisRaw("Vertical");

		if (Input.GetButton("Fire1")) {
			m_isPunching = true;
			m_attackStrength = 5;
			StartCoroutine(AttackRoutine());
		}

		if (Input.GetButton("Fire2")) {
			m_isPunching = true;
			m_attackStrength = 10;
			StartCoroutine(AttackRoutine());
		}
	}

	/// <summary>
	/// Allows the player to move forwards and backwards, dependent on direction player is facing
	/// </summary>
	private void Movement() {
		// Changes the rotation of the character
		float horizontal = m_horizontal * m_turningSpeed * Time.deltaTime;
		transform.Rotate(0, horizontal, 0);

		if (m_vertical != 0) {
			Vector3 movement = m_movementSpeed * m_vertical * transform.forward;
			//m_movement = m_movementSpeed * vertical;
			//rb.velocity += movementSpeed * Time.deltaTime * vertical * transform.forward;
			m_rb.AddForce(movement);
			//m_rb.velocity = new Vector3(0, 0, m_movement);	// Moves on set axis
		} else {    // Stops moving if player isn't clicking
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
				m_building.TakeDamage(m_attackStrength);
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