using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : MonoBehaviour
{
    public Rigidbody2D rb;
    public float maxSpeed = 10;
    public float rotationSpeed = 100;
    private Vector2 movementVector;

    public float acceleration = 70;
    public float desaceleration = 50;
    public float currentSpeed = 0;
    public float currentForewardDirection = 1;


    private void Awake()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }

    public void Move(Vector2 movementVector)
    {
     this.movementVector = movementVector;
     CalculateSpeed(movementVector);
        if (movementVector.y > 0)
            currentForewardDirection = 1;
        else if (movementVector.y < 0)
            currentForewardDirection = 0;
    }

    private void CalculateSpeed(Vector2 movementVector)
    {
        throw new NotImplementedException();
    }

    private void FixedUpdate()
    {
        rb.velocity = (Vector2)transform.up * currentSpeed * Time.fixedDeltaTime;
        rb.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movementVector.x * rotationSpeed * Time.fixedDeltaTime));
    }
}
