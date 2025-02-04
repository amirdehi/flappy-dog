using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isGameOver = false;

    void Update()
    {
        if (isGameOver)
        {
            if (Input.GetMouseButtonDown(0)) // Tap to restart
            {
                isGameOver = false;
                Time.timeScale = 1; // Unpause the game
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
