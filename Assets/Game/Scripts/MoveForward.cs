using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 300f; // Misma velocidad que tu MapScroller

    void Update()
    {
        // Se mueve hacia atrás para simular que el jugador avanza
        transform.position += Vector3.back * speed * Time.deltaTime;

        // Si se sale del mapa por detrás, se destruye para no gastar memoria
        if (transform.position.z < -50) 
        {
            Destroy(gameObject);
        }
    }
}