using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed = 20.0f;
    public float rotationSpeed = 100.0f;

    [Header("Disparo")]
    public GameObject bulletPrefab;    // Para poner prefab bala
    public Transform bulletSpawn;   // El punto donde va a salir la bala
    
    private Vector2 moveInput;

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    // Unity llama a la accion OnFire (Clic izq, Espacio o Gatillo der)
    void OnAttack(InputValue value)
    {
        // Si el boton esta presionado
        if (value.isPressed)
        {
            // Crea copia de la bala, en la posicion y rotacion del punto de disparo
            Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        }
    }
    void Update()
    {
        //Mueve el avion hacia adelante constantemente
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);

        //Aplica la rotacion basada en lo que guardo OnMove
        //Inclinacion (Pitch) con W/S o Flechas Arriba/Abajo (Eje X)
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime * moveInput.y); 
        
        // ---ALABEO!---
        // Alabeo (Roll) con A/D o Flechas Izquierda/Derecha (Eje Z)
        // Vector3.back para que baje ala derecha al mover a la derecha
        transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime * moveInput.x); 
    }
}