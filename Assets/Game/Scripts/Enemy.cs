using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int hitCount = 0;
    private int hitsToDestroy = 2;
    
    [Header("Puntos")]
    public int pointsValue = 5; // Puntos que suma al morir cada enemigo

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            hitCount++;
            Debug.Log("Enemigo golpeado: " + hitCount + "/" + hitsToDestroy);

            Destroy(other.gameObject); // Destruye la bala

            if (hitCount >= hitsToDestroy)
            {
                //Referencia al jugador y le suma los puntos
                PlayerController player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
                if (player != null)
                {
                    player.AddScore(pointsValue);
                }
                // Sonido destruccion enemigo
                if (AudioManager.Instance != null)
                    AudioManager.Instance.PlayDestruccionEnemigo();

                Debug.Log("¡Enemigo destruido!");
                Destroy(gameObject);
            }
        }
    }
}