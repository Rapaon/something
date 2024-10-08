using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadSceneAsync(0);
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.score = 0;
        gameManager.health = 3;
        gameManager.asteroidCount = 0;
        gameManager.asteroid1Count = 0;
        gameManager.asteroid2Count = 0;
        gameManager.asteroid3Count = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
