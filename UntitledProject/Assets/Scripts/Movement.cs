using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    private float HorizontalInput;
    private float VerticalInput;
    public float MovementSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");
            rb.velocity = new Vector3(HorizontalInput * MovementSpeed, rb.velocity.y, VerticalInput * MovementSpeed);
    }
}
