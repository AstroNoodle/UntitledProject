using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject CamTarget;
    public GameObject Player;
    public GameObject Player1;
    public Rigidbody rb;
    public Rigidbody rb1;
    public float MovementSpeed;
    public float DownForce;
    public float DownForceRayLenght;
    public float MaxDistance;
    public List<Transform> Targets;
    private float distance;
    private float HorizontalInput;
    private float VerticalInput;
    private float HorizontalInput1;
    private float VerticalInput1;

    private void Start()
    {
        rb = Player.GetComponent<Rigidbody>();
        rb1 = Player1.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        PlayerMovement();
        Player1Movement();
        if (Targets.Count == 0)
            return;
        Vector3 CenterPoint = GetCenterPoint();
        CamTarget.transform.position = CenterPoint;
        distance = Vector3.Distance(Player.transform.position, Player1.transform.position);
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

        if(distance > MaxDistance)
        {
            //Player.transform.position = new Vector3(Mathf.Clamp(Player.transform.position.x, distance, MaxDistance), Player.transform.position.y, Player.transform.position.z);
        }
    }

    private void Player1Movement()
    {
        HorizontalInput1 = Input.GetAxis("Horizontal1");
        VerticalInput1 = Input.GetAxis("Vertical1");
        rb1.velocity = new Vector3(HorizontalInput1 * MovementSpeed, rb1.velocity.y, VerticalInput1 * MovementSpeed);

        if ((HorizontalInput1 != 0 || VerticalInput1 != 0) && OnSlope1())
        {
            rb1.velocity = new Vector3(HorizontalInput1 * MovementSpeed, rb1.velocity.y + DownForce, VerticalInput1 * MovementSpeed);
        }
        if (distance > MaxDistance)
        {
            //Player1.transform.position = new Vector3(Mathf.Clamp(Player1.transform.position.x, distance, MaxDistance), Player1.transform.position.y, Player1.transform.position.z);
        }
    }

    private bool OnSlope()
    {
        RaycastHit Hit;
        if (Physics.Raycast(Player.transform.position, Vector3.down, out Hit, DownForceRayLenght))
            if (Hit.normal != Vector3.up)
                return true;
            return false;
    }

    private bool OnSlope1()
    {
        RaycastHit Hit1;
        if (Physics.Raycast(Player1.transform.position, Vector3.down, out Hit1, DownForceRayLenght))
            if (Hit1.normal != Vector3.up)
                return true;
            return false;
    }

    Vector3 GetCenterPoint()
    {
        if (Targets.Count == 1)
        {
            return Targets[0].position;
        }

        var bounds = new Bounds(Targets[0].position, Vector3.zero);
        for (int i = 0; i < Targets.Count; i++)
        {
            bounds.Encapsulate(Targets[i].position);
        }
        return bounds.center;
    }
}
