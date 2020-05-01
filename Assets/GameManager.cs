using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    static int playerScore01 = 0;
    static int playerScore02 = 0;

    public GUISkin theSkin;
    private Transform theBall;

    private void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball").transform;
    }

    //use for init. takes wall name and score to correct player
    public static void score(string wallName)
    {
        if (wallName == "rightWall")
        {
            playerScore01 += 1;
        }
        else
        {
            playerScore02 += 1;
        }
    }
    void OnGUI()
    {
        GUI.skin = theSkin;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 18, 25, 100, 100), "" + playerScore01);//-18 is half the width of the font size
        GUI.Label(new Rect(Screen.width / 2 + 150 - 18, 25, 100, 100), "" + playerScore02);

        if(GUI.Button ( new Rect (Screen.width/2 - 121/2, 35, 121, 53), "RESET"))
        {
            playerScore01 = 0;
            playerScore02 = 0;

            theBall.gameObject.SendMessage("ResetBall");
        }
    }
}
