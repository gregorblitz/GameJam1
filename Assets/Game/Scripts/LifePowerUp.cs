using UnityEngine;

public class LifePowerUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Verificamos lo choco (Tag "Player")
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();

            if (player != null)
            {
                // Da una vida al jugador
                player.AddLife();
            }

            // Destruye powerup de la escena
            Destroy(gameObject);
        }
    }
}
