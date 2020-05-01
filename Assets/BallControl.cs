using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {

    public float ballSpeed = 80;
    private float ballVelX = 16;
    private Rigidbody2D rb2D;
    private Transform tr2D;

    // Use this for initialization
    void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        tr2D = GetComponent<Transform>();
        Invoke("GoBall", 2.0f);
    }

    void Update()
    {
        float xVel = rb2D.velocity.x;
        //Debug.Log("Velocity: " + xVel);//to find velocity b/c ballspeed isn't the ball spd but val for addForce that produce velocity
        //force velocity speed of 20 if between 15 and -15. Don't include zero when ball isn't moving at game start.
        if (xVel < 15 && xVel > -15 && xVel != 0)//
        {
            if(xVel > 0)
            {
                rb2D.velocity = new Vector2(ballVelX,rb2D.velocity.y);
            }
            else{

                rb2D.velocity = new Vector2(-ballVelX, rb2D.velocity.y);
            }
            //Debug.Log("Velocity before " + xVel);
            //Debug.Log("Velocity after " + rb2D.velocity.x);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            float velY = rb2D.velocity.y;
            velY = velY / 2 + collision.collider.GetComponent<Rigidbody2D>().velocity.y / 3;// when ball hits paddle the velocity of paddle will affect ball
            rb2D.velocity = new Vector2(rb2D.velocity.x, velY);
            GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.2f);
            GetComponent<AudioSource>().Play();
        }
    }

    private void ResetBall()
    {

        rb2D.velocity = Vector2.zero;
        tr2D.position = new Vector2(0, 0);

        Invoke("GoBall", 2.0f);

    }

    private void GoBall()
    {
        int ranNum = Random.Range(0, 2);
        if (ranNum < 0.5)
        {
            rb2D.AddForce(new Vector2(ballSpeed, 10));
        }
        else
        {
            rb2D.AddForce(new Vector2(-ballSpeed, -10));
        }
    }
}
