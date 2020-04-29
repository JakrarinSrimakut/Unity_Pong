
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    public KeyCode moveUp;
    public KeyCode moveDown;

    public float speed = 10f;
    private Rigidbody2D rb2d; //RIgidbody inside our object

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(moveUp))
        {
            rb2d.velocity = new Vector2(0, speed);
        }
        else if (Input.GetKey(moveDown))
        {
            rb2d.velocity = new Vector2(0, -speed);
        }
        else
        {
            rb2d.velocity = Vector2.zero;
        }
    }
}
