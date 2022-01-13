// Fix gliding / second delay from when you release button


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the player's controls
/// </summary>
public class PlayerBehaviour : MonoBehaviour
{
    BuildingBehaviour buildingScipt;
    Rigidbody rb;

    // Movement variables
    private float _vertical, _horizontal;
    private readonly float _movementSpeed = 50;
    private readonly float _turningSpeed = 150;

    // Attack variables
    private bool _isPunching;
    private float _attackStrength;

    public Joystick joystick;

    /// <summary>
    /// Get references to components
    /// </summary>
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Removes cursor while ingame and initialises variables
    /// </summary>
    void Start()
    {
        _isPunching = false;

        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    /// <summary>
    /// Calls the player input to see any input changes
    /// </summary>
    void Update()
    {
        PlayerInput();
    }

    /// <summary>
    /// Allows for the player to be able to move the character
    /// </summary>
    private void FixedUpdate()
    {
        Movement();
    }

    /// <summary>
    /// Assigns all variables to an input value
    /// </summary>
    private void PlayerInput()
    {
        //_horizontal = Input.GetAxisRaw("Horizontal");
        //_vertical = Input.GetAxisRaw("Vertical");

        _horizontal = joystick.Horizontal;
        _vertical = joystick.Vertical;

        //if (Input.GetButton("Fire1"))
        //{
        //    _isPunching = true;
        //    _attackStrength = 5;
        //    StartCoroutine(AttackRoutine());
        //}

        //if (Input.GetButton("Fire2"))
        //{
        //    _isPunching = true;
        //    _attackStrength = 10;
        //    StartCoroutine(AttackRoutine());
        //}
    }

    /// <summary>
    /// Allows the player to move forwards and backwards, dependent on direction player is facing
    /// </summary>
    private void Movement()
    {
        // Changes the rotation of the character
        float horizontal = _horizontal * _turningSpeed * Time.deltaTime;
        transform.Rotate(0, horizontal, 0);

        if (_vertical != 0)
        {
            Vector3 movement = _movementSpeed * _vertical * transform.forward;
            //m_movement = m_movementSpeed * vertical;
            //rb.velocity += movementSpeed * Time.deltaTime * vertical * transform.forward;
            rb.AddForce(movement);
            //m_rb.velocity = new Vector3(0, 0, m_movement);	// Moves on set axis
        }
        else
        {    // Stops moving if player isn't clicking
            rb.velocity = Vector3.zero;
        }
    }

    /// <summary>
    /// If the player is touching a building and attacks it, building will lose health
    /// </summary>
    /// <param name="collision">other game object that player touches</param>
    private void OnCollisionStay(Collision collision)
    {
        if (_isPunching)
        {
            if (collision.gameObject.CompareTag("Building"))
            {
                buildingScipt = collision.gameObject.GetComponent<BuildingBehaviour>();
                buildingScipt.TakeDamage(_attackStrength);
                _isPunching = false;
            }
        }
    }

    /// <summary>
    /// Makes sure player isn't always punching
    /// </summary>
    /// <returns>When the next FixedUpdate is called, punch is made not active</returns>
    IEnumerator AttackRoutine()
    {
        yield return new WaitForFixedUpdate();

        _isPunching = false;
    }

    public void Attack1()
    {
        _isPunching = true;
        _attackStrength = Random.Range(10, 50);
        StartCoroutine(AttackRoutine());
    }

    public void Attack2()
    {
        _isPunching = true;
        _attackStrength = Random.Range(50, 100);
        StartCoroutine(AttackRoutine());
    }
}
