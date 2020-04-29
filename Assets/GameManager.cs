using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    static int playerScore01 = 0;
    static int playerScore02 = 0;

    public GUISkin theSkin;

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
        Debug.Log("player score 1 is " + playerScore01);
        Debug.Log("player score 2 is " + playerScore02);
    }
    void OnGUI()
    {
        GUI.skin = theSkin;
        GUI.Label(new Rect(Screen.width / 2 - 150 -12, 25, 100, 100), "" + playerScore01);//-12 is half the width of the font size
        GUI.Label(new Rect(Screen.width / 2 + 150 -12, 25, 100, 100), "" + playerScore02);
    }
}
