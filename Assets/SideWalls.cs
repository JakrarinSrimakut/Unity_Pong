using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWalls : MonoBehaviour {

    private Transform tr2D;
	// Use this for initialization
	void Start () {
        tr2D = GetComponent<Transform>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Ball")
        {
            Debug.Log("Test");
            string wallName = tr2D.name;
            GameManager.score(wallName);
            collision.gameObject.SendMessage("ResetBall");
        }
    }
}
