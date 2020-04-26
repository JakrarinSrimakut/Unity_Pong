using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {

    private Rigidbody2D rb2D;
	// Use this for initialization
	void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        int ranNum = Random.Range(0, 2);
        if(ranNum < 0.5)
        {
            rb2D.AddForce(new Vector2(80, 10));
        }
        else
        {
            rb2D.AddForce(new Vector2(-80, -10));
        }
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
}
