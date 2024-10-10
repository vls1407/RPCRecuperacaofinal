using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : MonoBehaviour
{
    public Rigidbody2D rb;
    public float maxSpeed = 10;
    public float rotationSpeed = 100;
    private Vector2 movementVector;

    private void Awake()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }

    public void Move(Vector2 movementVector)
    {
     this.movementVector = movementVector;
    }

    private void FixedUpdate()
    {
        rb.velocity = (Vector2)transform.up * movementVector.y * maxSpeed * Time.fixedDeltaTime;
        rb.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movementVector.x * rotationSpeed * Time.fixedDeltaTime));
    }
}
