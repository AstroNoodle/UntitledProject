using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 40;
    private int currentHealth;
    private float countDown = 5.0f;
    public float speed;

    public GameObject Player;


    void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        //countDown -= Time.deltaTime;
        //if (countDown > 0)
        //{
        //    transform.position += Vector3.forward * speed;
        //}
        //else if (countDown > -5.0f)
        //{
        //    transform.position += Vector3.back * speed;
        //}
        //if (countDown == -10.0f)
        //{
        //    countDown = 5.0f;
        //    countDown -= Time.deltaTime;
        //}
    }
    public void takeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");

        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        this.enabled = false;
    }
}
