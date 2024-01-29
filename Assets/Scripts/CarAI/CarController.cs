using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _torque = 0.5f;
    [SerializeField] private float _maxSpeed = 5f;
    [SerializeField] private Vector2 _movementVector;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector2 movementInput)
    {
        this._movementVector = movementInput;
    }

    private void FixedUpdate()
    {
        if(_rb.velocity.magnitude < _maxSpeed)
        {
            _rb.AddForce(_movementVector.y * transform.forward * _speed);
        }

        _rb.AddTorque(_movementVector.x * Vector3.up * _torque * _movementVector.y);
    }
}
