using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public bool isGameActive;

    public GameObject gameOverPanel;
    public GameObject pausePanel;
    private bool paused;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1;
        AudioManager.Instance.PlayMusicaAmbiente();
    }

    void ChangePaused()
    {
        if (!paused)
        {
            paused = true;
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            paused = false;
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangePaused();
        }
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverPanel.SetActive(true);
        AudioManager.Instance.StopAllAudio();
        Time.timeScale = 0;
        AudioManager.Instance.PlayMusicaGameOver();
        
    }

    public void StartGame()
    {
        isGameActive = true;
        
    }

     public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
