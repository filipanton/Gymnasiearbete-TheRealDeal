using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float jumpheight;
    public float movespeed;
    Rigidbody2D rb;

    private void Start()
    {
        //SO YOU CAN WRITE RB INSTEAD OF GET COMPONENT ALL THE TIME
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // WHEN YOU PRESS SPACE SOMETHING HAPPENS
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(0, jumpheight);
        }

        if(Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(movespeed, rb.velocity.y);

        }
        if(Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);
        }
    }
}

