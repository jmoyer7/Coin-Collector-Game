using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = .01f;
    public float baseSpeed = 5f;
    public float minTime;
    public float maxTime;
    private float timeLeft = 0;  //determines how much time is left before direction is changed
    private Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        movement = Random.insideUnitCircle.normalized;
        timeLeft = RandomTime();

    }
    float RandomTime()
    {
        return Random.Range(minTime, maxTime);
    }


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall") || collision.CompareTag("Protector") || collision.CompareTag("Player"))
        {
            ChangeDirection();
        }

    }

}



