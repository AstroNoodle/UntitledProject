using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    private float HorizontalInput;
    private float VerticalInput;
    public float MovementSpeed;
    public float DownForce;
    public float DownForceRayLenght;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(HorizontalInput * MovementSpeed, rb.velocity.y, VerticalInput * MovementSpeed);

        if ((HorizontalInput != 0 || VerticalInput != 0) && OnSlope())
        {
            rb.velocity = new Vector3(HorizontalInput * MovementSpeed, rb.velocity.y + DownForce, VerticalInput * MovementSpeed);
        }
    }

    private bool OnSlope()
    {
        RaycastHit Hit;
        if (Physics.Raycast(transform.position, Vector3.down, out Hit, DownForceRayLenght))
            if (Hit.normal != Vector3.up)
                return true;
        return false;
    }
}
