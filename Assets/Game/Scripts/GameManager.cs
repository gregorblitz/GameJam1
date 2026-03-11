using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public bool isGameActive;

    [Header("Textos Puntuación")]
    public TextMeshProUGUI finalScoreText; // Texto para el puntaje de esta partida
    public TextMeshProUGUI highScoreText;  // Texto para el record historico

    [Header("Paneles UI")]
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

        //SISTEMA HIGH SCORE
        //Busca al jugador para leer puntos hechos
        PlayerController player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        if (player != null)
        {
            int currentScore = player.score; 

            //Lee libreta de Unity para ver el record historico
            int highScore = PlayerPrefs.GetInt("HighScore", 0);

            // Se hizo un nuevo record?
            if (currentScore > highScore)
            {
                highScore = currentScore; // Actualiza el record por el actual
                PlayerPrefs.SetInt("HighScore", highScore); // se guarda
                PlayerPrefs.Save(); // Forzamos escritura en disco duro
                Debug.Log("¡Nuevo marca alcanzada: " + highScore + "!");
            }

            // Muestra textos en el Canvas
            if (finalScoreText != null)
            {
                finalScoreText.text = "Puntaje Final: " + currentScore;
            }

            if (highScoreText != null)
            {
                highScoreText.text = "Puntaje Mayor: " + highScore;
            }
        }
        
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
