using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour {

    public float blocktimer;
    public bool blockcollider;
    public bool playanimation;

    private void OnCollisionEnter2D(Collision2D Colliding_With)
    {
        Vector2 MyNormal2 = Colliding_With.contacts[0].normal;

        //collider
        if (MyNormal2.y <= -0.75)
        {
            blocktimer = 1f;
            blockcollider = true;
        }
    }


    private void Update()

    { 
        // The timer
        if (blocktimer > -1)

        {
            blocktimer -= Time.deltaTime;
        }

        else

        {
            blocktimer = -1;
        }
        //What happens 1 second after block collision
        if (blocktimer <= 0f && blockcollider == true)
        {

            GetComponent<Collider2D>().enabled = false;

            playanimation = true;

            //What happens 2 seconds after block collision
            if (blocktimer <= -1)
            {
                Destroy(gameObject);
                Debug.Log("it works");
            }

        }

    }
    
}
