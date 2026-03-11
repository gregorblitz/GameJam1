using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed = 20.0f;
    public float moveSmoothSpeed = 8f;

    [Header("Inclinacion Lateral (Roll)")]
    public float maxRollAngle = 45f;
    public float rollSmoothSpeed = 4f;

    [Header("Inclinacion Vertical (Pitch)")]
    public float maxPitchAngle = 45f;
    public float pitchSmoothSpeed = 4f;

    [Header("Limites del Mapa")]
    public float minY = 10f;
    public float maxY = 200f;
    public float minX = -150f;
    public float maxX = 150f;

    [Header("Disparo")]
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    private float fireRate = 2.0f;     // Tiempo entre balas

    [Header("Salud y UI")]
    public int currentLives = 1;
    public int maxLives = 5;
    public TextMeshProUGUI livesText;
 
    private float nextFire = 0f;      // Cronómetro interno
    private bool isAttacking = false; // UEVA: Estado del botón

    private Vector2 moveInput;
    private Vector2 smoothedInput;
    private float currentRoll = 0f;
    private float currentPitch = 0f;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        UpdateLivesUI();
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnAttack(InputValue value)
    {
        // Esto se vuelve true al presionar y false al soltar
        isAttacking = value.isPressed;
    }

    void Update()
    {
        smoothedInput = Vector2.Lerp(smoothedInput, moveInput, Time.deltaTime * moveSmoothSpeed);

        transform.Translate(Vector3.right * speed * Time.deltaTime * smoothedInput.x, Space.World);
        transform.Translate(Vector3.up * speed * Time.deltaTime * smoothedInput.y, Space.World);

        float clampX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(clampX, clampY, transform.position.z);

        float targetRoll = smoothedInput.x * maxRollAngle;
        currentRoll = Mathf.Lerp(currentRoll, targetRoll, Time.deltaTime * rollSmoothSpeed);

        float targetPitch = smoothedInput.y * maxPitchAngle;
        currentPitch = Mathf.Lerp(currentPitch, targetPitch, Time.deltaTime * pitchSmoothSpeed);

        transform.rotation = Quaternion.Euler(-90f + currentPitch, 180f, currentRoll);

        // Si esta oprimido boton (atacando) y ya paso el tiempo de espera (fireRate)
        if (isAttacking && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate; // Programamos el siguiente disparo
            Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        }
    }

    public void ActivateAmmoPowerUp(float fastRate, float duration)
    {
        StartCoroutine(AmmoBoostRoutine(fastRate, duration));
    }

    private System.Collections.IEnumerator AmmoBoostRoutine(float fastRate, float duration)
    {
        float originalRate = fireRate;
        fireRate = fastRate; // aumenta la cadencia de disparo
        
        yield return new WaitForSeconds(duration);
        
        fireRate = originalRate; // Al terminar el tiempo, vuelve a la normalidad
    }

    // Actualizar el texto en pantalla
    private void UpdateLivesUI()
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + currentLives;
        }
    }

    // Llama el PowerUp para dar vida
    public void AddLife()
    {
        if (currentLives < maxLives)
        {
            currentLives++;
            UpdateLivesUI();
        }
    }
    // Quita vidas
    /*public void TakeDamage()
    {
        currentLives--;
        UpdateLivesUI();

        if (currentLives <= 0)
        {
            GameOver();
        }
    }

    // Congela el juego cuando mueres
    private void GameOver()
    {
        Debug.Log("¡Juego Terminado!");
        Time.timeScale = 0f; // pausa el juego
        // Espacio para mostrar una pantalla de reinicio
    }*/

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstaculo"))
        {
            Debug.Log("¡Colisión con obstáculo!");
            gameManager.GameOver();
        }
    }
}