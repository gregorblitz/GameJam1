using UnityEngine;
using UnityEngine.InputSystem;

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

    private Vector2 moveInput;
    private Vector2 smoothedInput;
    private float currentRoll = 0f;
    private float currentPitch = 0f;

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnAttack(InputValue value)
    {
        if (value.isPressed)
        {
            Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
        }
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
    }
}