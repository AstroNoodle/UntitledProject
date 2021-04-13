using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public GameObject player;
    public GameObject Player1;
    public float speed;

    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 player = gameObject.transform.position;
    }
}
