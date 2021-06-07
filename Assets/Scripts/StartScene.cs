using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    public void StartGame()
    {
        Application.LoadLevel("Main");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
