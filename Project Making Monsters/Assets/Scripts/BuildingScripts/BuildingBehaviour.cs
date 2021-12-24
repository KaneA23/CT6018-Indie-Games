using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls anything involving the buildings
/// </summary>
public class BuildingBehaviour : MonoBehaviour
{
    private float _maxHealth;
    private float _health;

    Color colour;

    Renderer render;

    /// <summary>
    /// Gets the render component
    /// </summary>
    private void Awake()
    {
        render = gameObject.GetComponent<Renderer>();
    }

    /// <summary>
    /// Assigns building's initial health
    /// </summary>
    void Start()
    {
        _maxHealth = Random.Range(1000, 2500);
        _health = _maxHealth;
        Debug.Log(gameObject.name + ": " + _health);

        render.material.color = Color.grey;
    }

    void Update()
    {
        // If the building has no health, it is destroyed
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Building takes damage dependent on strength of player's attack
    /// </summary>
    /// <param name="a_damage">Amount of health building loses</param>
    public void TakeDamage(float a_damage)
    {
        _health -= a_damage;
        Debug.Log(gameObject.name + ": " + _health);

        // Changes colour of building to show damage taken (whitebox only)
        colour.r += a_damage / _maxHealth;
        render.material.color = colour;
    }
}
