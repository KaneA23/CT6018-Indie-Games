// Make attack less jancky

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Controls anything involving the buildings
/// </summary>
public class BuildingBehaviour : MonoBehaviour {
	public float health;

	Color colour;
	Renderer render;

	void Start() {
		health = 100;

		render = gameObject.GetComponent<Renderer>();
		render.material.color = Color.grey;
	}

	void Update() {
		// If the building has no health, it is destroyed
		if (health <= 0) {
			Destroy(gameObject);
		}
	}

	/// <summary>
	/// Building takes damage dependent on strength of player's attack
	/// </summary>
	/// <param name="a_damage">Amount of health building loses</param>
	public void TakeDamage(float a_damage) {
		health -= a_damage;
		Debug.Log(gameObject.name + ": " + health);

		// Changes colour of building to show damage taken (whitebox only)
		colour.r += (a_damage / 100);
		render.material.color = colour;
	}
}