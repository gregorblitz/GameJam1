using UnityEngine;

public class GasPickup : MonoBehaviour
{
    public GameObject gasEffect; // Arrastra FX_Gas aquí en el Inspector

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gasEffect != null)
            {
                Vector3 spawnPos = transform.position; // Guarda posición antes de destruir
                Instantiate(gasEffect, spawnPos, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}