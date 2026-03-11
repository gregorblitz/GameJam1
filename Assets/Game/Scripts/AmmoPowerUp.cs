using UnityEngine;

public class AmmoPowerUp : MonoBehaviour
{
    public float fastFireRate = 0.1f; // Cadencia ultra rapida
    public float duration = 5f;       // Duracion del efecto

    // Funcion que detecta el choque (colision)
    private void OnTriggerEnter(Collider other) 
    {
        // Lo que me toco tiene el Tag "Player"?
        if (other.CompareTag("Player")) 
        {
            //Buscamos el componente PlayerController en el avion
            PlayerController player = other.GetComponent<PlayerController>();

            if (player != null)
            {
                //Activamos el PowerUp en el avion
                player.ActivateAmmoPowerUp(fastFireRate, duration);
                Debug.Log("¡Munición especial activada!");
            }
            Destroy(gameObject);
        }
    }
}
