using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScene : MonoBehaviour
{
    public void MoveStart()
    {
        Application.LoadLevel("Start");
    }
    public void GameQuit()
    {
        Application.Quit();
    }
}
