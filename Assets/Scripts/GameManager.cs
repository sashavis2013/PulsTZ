using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject[] GameElements;
    public GameObject GameOverUI;
    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        Instance = this;
        Application.targetFrameRate = 60;
    }

    public void RestartGame()
    {
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        foreach (var element in GameElements)
        {
            element.SetActive(false);
        }
        GameOverUI.SetActive(true);
    }
}
