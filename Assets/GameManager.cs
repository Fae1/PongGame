using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    static int playerScore01 = 0;
    static int playerScore02 = 0;

    public GUISkin _theSkin;//Why do I cannot to use "new"?
    //Layout and anymore
    public GameObject[] theBallObjects;
    public Transform ballTrans;

    public void Start()
    {
        theBallObjects = GameObject.FindGameObjectsWithTag("Ball");
        foreach(GameObject Ball in theBallObjects)
        {
            ballTrans = Ball.transform;
        }
    }

    public void Score(string wallName)
    {
        if(wallName == "rightWall")
        {
            playerScore01 += 1;
        }
        else
        {
            playerScore02 += 1;
        }
        Debug.Log("Player Score 1 is: " + playerScore01);
        Debug.Log("Player Score 2 is: " + playerScore02);
    }
    public void OnGUI()
    {
        GUI.skin = _theSkin;
        GUI.Label(new Rect(Screen.width/2-310-12, 20, 300, 100), "Jogador 1\n" + playerScore01);
        GUI.Label(new Rect(Screen.width/2+150-12, 20, 300, 100), "Jogador 2\n" + playerScore02);

        if (GUI.Button (new Rect (Screen.width/2 - 60, 32, 121, 53), "RESET"))
        {
            playerScore01 = 0;
            playerScore02 = 0;

            ballTrans.gameObject.SendMessage("ResetBall");
        }
    }
}
