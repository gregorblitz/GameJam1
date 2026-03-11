using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int hitCount = 0;
    private int hitsToDestroy = 2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            hitCount++;
            Debug.Log("Enemigo golpeado: " + hitCount + "/" + hitsToDestroy);

            Destroy(other.gameObject); // Destruye la bala

            if (hitCount >= hitsToDestroy)
            {
                Debug.Log("¡Enemigo destruido!");
                Destroy(gameObject); // Destruye al enemigo
            }
        }
    }
}