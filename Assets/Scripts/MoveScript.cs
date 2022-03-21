using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{

    public float JumpPower=1;
    public float Speed=2;

    private Rigidbody2D _rb;
    private Transform _transform;
    private GameObject[] _ground;

    private bool _gravityChanged = false;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        _ground = GameObject.FindGameObjectsWithTag("Ground");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
        Speed += 0.0001f;
    }

    private void FixedUpdate()
    {
        
    }

    public void ChangeGravity()
    {
        _rb.gravityScale = -_rb.gravityScale;
            _gravityChanged = true;
    }

    private void MoveForward()
    {
        _transform.Translate(Vector2.right* Time.deltaTime*Speed);
    }
    public void DoJump()
    {
        if (IsGrounded())
        {
            if (_gravityChanged)
            {
                ChangeGravity();
                _gravityChanged = false;
            }
            _rb.AddForce(Vector2.up*JumpPower, ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        if (_rb.IsTouching(_ground[0].GetComponent<Collider2D>()) ||
            _rb.IsTouching(_ground[1].GetComponent<Collider2D>()))
            return true;
        return false;
    }
}
