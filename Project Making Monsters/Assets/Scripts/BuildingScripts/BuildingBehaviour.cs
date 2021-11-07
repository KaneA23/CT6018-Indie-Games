using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Controls anything involving the buildings
/// </summary>
public class BuildingBehaviour : MonoBehaviour {
	private float m_maxHealth;
	public float m_health;

	Color m_colour;
	Renderer m_render;

	void Start() {
		m_maxHealth = Random.Range(1000, 5000);
		m_health = m_maxHealth;
		Debug.Log(gameObject.name + ": " + m_health);

		m_render = gameObject.GetComponent<Renderer>();
		m_render.material.color = Color.grey;
	}

	void Update() {
		// If the building has no health, it is destroyed
		if (m_health <= 0) {
			Destroy(gameObject);
		}
	}

	/// <summary>
	/// Building takes damage dependent on strength of player's attack
	/// </summary>
	/// <param name="a_damage">Amount of health building loses</param>
	public void TakeDamage(float a_damage) {
		m_health -= a_damage;
		Debug.Log(gameObject.name + ": " + m_health);

		// Changes colour of building to show damage taken (whitebox only)
		m_colour.r += a_damage / m_maxHealth;
		m_render.material.color = m_colour;
	}
}