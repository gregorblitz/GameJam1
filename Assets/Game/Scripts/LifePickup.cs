using UnityEngine;

public class LifePickup : MonoBehaviour
{
    public GameObject lifeEffect; // Arrastra FX_Life aquí en el Inspector

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Instancia el efecto en la posición del objeto
            if (lifeEffect != null)
            {
                Vector3 spawnPos = transform.position; // Guarda posición antes de destruir
                Instantiate(lifeEffect, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}