using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private PlayerStats stats;

    [SerializeField] private float speed;
    public Vector2 MovementDirection => _movementDirection;
    public bool MovementOn => _movementDirection.magnitude > 0f;


    private Rigidbody2D _rigibody2D;
    private Vector2 _movementDirection;
    private Vector2 _input;

    

    private void Awake()
    {
        _rigibody2D = GetComponent<Rigidbody2D>(); 
    }
    void Start()
    {
        speed = stats.speed;
    }

    // Update is called once per frame
    void Update()
    {
        speed = stats.speed; // puede llevarse mucho
        _input = new Vector2(x: Input.GetAxisRaw("Horizontal"), y: Input.GetAxisRaw("Vertical"));

        //X
        if (_input.x > 0.1f)
        {
            _movementDirection.x = 1f;
        }
        else if (_input.x < 0f)
        {
            _movementDirection.x = -1f;
        }
        else
        {
            _movementDirection.x = 0f;
        }

        //Y
        if (_input.y > 0.1f)
        {
            _movementDirection.y = 1f;
        }
        else if (_input.y < 0f)
        {
            _movementDirection.y = -1f;
        }
        else
        {
            _movementDirection.y = 0f;
        }
    }
    private void FixedUpdate()
    {
        _rigibody2D.MovePosition(_rigibody2D.position + _movementDirection * speed * Time.fixedDeltaTime);
    }
}
