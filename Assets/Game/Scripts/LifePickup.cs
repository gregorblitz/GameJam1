using UnityEngine;

public class LifePickup : MonoBehaviour
{
    public GameObject lifeEffect; // Arrastra FX_Life aquí en el Inspector

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (lifeEffect != null)
            {
                Vector3 spawnPos = transform.position; // Guarda posición antes de destruir
                Instantiate(lifeEffect, spawnPos, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}