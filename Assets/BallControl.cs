using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {

    public float ballSpeed = 80;

    private Rigidbody2D rb2D;
    private Transform tr2D;

    // Use this for initialization
    void Start () {
        Invoke("GoBall", 2.0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            float velY = rb2D.velocity.y;
            velY = velY / 2 + collision.collider.GetComponent<Rigidbody2D>().velocity.y / 3;// when ball hits paddle the velocity of paddle will affect ball
            rb2D.velocity = new Vector2(rb2D.velocity.x, velY);
        }
    }

    private void ResetBall()
    {
        rb2D = GetComponent<Rigidbody2D>();
        tr2D = GetComponent<Transform>();

        rb2D.velocity = Vector2.zero;
        tr2D.position = new Vector2(0, 0);

        Invoke("GoBall", 2.0f);

    }

    private void GoBall()
    {
        rb2D = GetComponent<Rigidbody2D>();
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
