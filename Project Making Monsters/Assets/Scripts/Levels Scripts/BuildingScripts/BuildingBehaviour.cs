using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls anything involving the buildings
/// </summary>
public class BuildingBehaviour : MonoBehaviour
{
    private int _maxHealth;
    private float _health;

    Color colour;
    Renderer render;

    GameObject canvas;
    ScoreSystem scoreSystem;

    /// <summary>
    /// Gets the render component
    /// </summary>
    private void Awake()
    {
        render = gameObject.GetComponent<Renderer>();
        
        canvas = GameObject.Find("Canvas");
        scoreSystem = canvas.GetComponentInChildren<ScoreSystem>();
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
            scoreSystem.ChangeScore(1000 * scoreSystem.multiplier);
        }
    }

    /// <summary>
    /// Building takes damage dependent on strength of player's attack
    /// </summary>
    /// <param name="a_damage">Amount of health building loses</param>
    public void TakeDamage(float a_damage)
    {
        a_damage *= 1 + (scoreSystem.multiplier / 100);
        _health -= a_damage;
        Debug.Log(gameObject.name + ": " + _health);
        scoreSystem.ChangeScore(a_damage);

        // Changes colour of building to show damage taken (whitebox only)
        colour.r += a_damage / _maxHealth;
        render.material.color = colour;
    }
}
