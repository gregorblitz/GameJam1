using UnityEngine;
using UnityEngine.InputSystem; // Obligatorio para leer los valores

public class PlayerController : MonoBehaviour
{
    public float speed = 20.0f;
    public float rotationSpeed = 100.0f;

    // Aquí guardaremos los datos que nos envíe el Player Input
    private Vector2 moveInput;

    // ¡La magia de Send Messages! 
    // Unity llama a esta función automáticamente cuando tocas las teclas de movimiento.
    void OnMove(InputValue value)
    {
        // Extraemos el valor del joystick o teclado (X e Y) y lo guardamos
        moveInput = value.Get<Vector2>();
    }

    void Update()
    {
        // 1. Mover el avión hacia adelante constantemente
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // 2. Aplicar la rotación basada en lo que guardó OnMove
        // Inclinación (Pitch) con W/S o Flechas Arriba/Abajo
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime * moveInput.y); 
        
        // Giro (Yaw) con A/D o Flechas Izquierda/Derecha
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * moveInput.x); 
    }
}