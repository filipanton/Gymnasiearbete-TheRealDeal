using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playercontroller2 : MonoBehaviour
{

    public float movespeed;
    public float jumpforce;
    public int Player_Grounded;
    public bool touchwallright;
    public bool touchwallleft;
    public bool Allow_Double_Jump;
    public bool touchingfloor;
    public bool touchobstacle;
    public float inputtimer;
    public float deathtimer;
    public bool Edgelimit;

    Rigidbody2D rb;


    private void Start()
    {
    // Instead of writing all GetCOmponent<Rigidbody2D>() write rb.
        rb = GetComponent<Rigidbody2D>();
    }

    // What happens when touching something 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Obstacle")
        {
            touchobstacle = true;
        }
        
        
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

            if (Colliding_With.gameObject.tag == "Edge")
            {
                Edgelimit = true;
            }
        }

        // Whats happens when touching the left side surface of an platform.
        if (MyNormal.x <= -0.75)
        {
            touchwallleft = true;

            if (Colliding_With.gameObject.tag == "Edge")
            {
                Edgelimit = true;
            }
        }

        

    }
    
    // What happens when the player stops touching an object.
    void OnCollisionExit2D(Collision2D Colliding_With)
    {


        Player_Grounded = 1;




        touchingfloor = false;
        touchwallright = false;
        touchwallleft = false;
        Edgelimit = false;

    }


    private void Update()
        // Timer for the no-input after walljump
    {
        if (inputtimer > 0)
        {
            inputtimer -= Time.deltaTime;
        }
        else
        {
            inputtimer = 0;
        }

        // Timer for delay when restarting scene
        if (deathtimer > 0)
        {
            deathtimer -= Time.deltaTime;
        }
        else
        {
            deathtimer = 0;
        }



        //if touching the ground my player wont slide
        if (Player_Grounded == 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        // When pressing space and the player grounded is less than 2 the player will be able to jump
        if (Input.GetKeyDown(KeyCode.Space) && (Player_Grounded < 2) && touchobstacle == false)
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


        if (touchwallright == true && Input.GetKeyDown(KeyCode.Space) && touchingfloor == false && touchobstacle == false)
        {
            if (Edgelimit != true)
            {
                Player_Grounded++;
                rb.velocity = new Vector2(45, 65);
                inputtimer = 0.2f;
                transform.localScale = new Vector2(1, 1);
            }
            

        }

        if (touchwallleft == true && Input.GetKeyDown(KeyCode.Space) && touchingfloor == false && touchobstacle == false)
        {
            if (Edgelimit != true)
            {

                rb.velocity = new Vector2(-45, 65);
                inputtimer = 0.2f;
                transform.localScale = new Vector2(-1, 1);
            }
        }

        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && inputtimer == 0 && touchobstacle == false && (Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.LeftArrow) == false))
        {
            rb.velocity = new Vector2(movespeed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }

        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && inputtimer == 0 && touchobstacle == false && (Input.GetKey(KeyCode.D) == false && Input.GetKey(KeyCode.RightArrow) == false))
        {
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);


        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            gameObject.GetComponent<Renderer>().material.color = Color.magenta;
        }

        if (touchobstacle == true && deathtimer ==0 )
        {
            deathtimer = 3;
            
        }
        if (touchobstacle == true && deathtimer < 1 && deathtimer > 0.8f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


}