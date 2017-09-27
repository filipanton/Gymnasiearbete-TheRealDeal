using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller2 : MonoBehaviour
{

    public float movespeed;
    public float jumpforce;
    public int Player_Grounded;
    public bool touchwallright;
    public bool touchwallleft;
    public bool Allow_Double_Jump;
    public bool touchingfloor;

    public float inputtimer;


    Rigidbody2D rb;


    private void Start()
    {
    // Instead of writing all GetCOmponent<Rigidbody2D>() write rb.
        rb = GetComponent<Rigidbody2D>();
    }

    // What happens when the player is touching the platform.
    void OnCollisionStay2D(Collision2D Colliding_With)
    {
        Vector2 MyNormal = Colliding_With.contacts[0].normal;

        // Whats happens when touching the top surface of an platform.

        if (MyNormal.y >= 0.75)
        {
            Player_Grounded = 0;
            Allow_Double_Jump = true;
            touchingfloor = true;
        }

        // Touching any of the sides or the bottom of an platform makes the player unable to double jump.
        else
        {
            Allow_Double_Jump = false;

        }

        // Whats happens when touching the right side surface of an platform.
        if (MyNormal.x >= 0.75)

        {
            touchwallright = true;
        }

        // Whats happens when touching the left side surface of an platform.
        if (MyNormal.x <= -0.75)
        {
            touchwallleft = true;
        }


    }
    // What happens when the player stops touching an object.
    void OnCollisionExit2D(Collision2D Colliding_With)
    {


        Player_Grounded = 1;




        touchingfloor = false;
        touchwallright = false;
        touchwallleft = false;
    }


    private void Update()

    {
        if (inputtimer > 0)
        {
            inputtimer -= Time.deltaTime;
        }
        else
        {
            inputtimer = 0;
        }




        if (Player_Grounded == 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }


        if (Input.GetKeyDown(KeyCode.Space) && (Player_Grounded < 2))
        {
            if (Allow_Double_Jump == true || Player_Grounded == 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpforce);
                if (Player_Grounded >= 1)
                {
                    Player_Grounded++;

                }
            }
        }


        if (touchwallright == true && Input.GetKeyDown(KeyCode.Space) && touchingfloor == false)
        {
            Player_Grounded++;
            rb.velocity = new Vector2(45, 65);
            inputtimer = 0.2f;

            Debug.Log(touchwallright);

        }

        if (touchwallleft == true && Input.GetKeyDown(KeyCode.Space) && touchingfloor == false)
        {
            rb.velocity = new Vector2(-45, 65);
            inputtimer = 0.2f;

        }

        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && inputtimer == 0)
        {
            rb.velocity = new Vector2(movespeed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }

        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && inputtimer == 0)
        {
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);


        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            gameObject.GetComponent<Renderer>().material.color = Color.magenta;
        }

    }


}