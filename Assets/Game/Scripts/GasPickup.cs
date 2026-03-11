using UnityEngine;

public class GasPickup : MonoBehaviour
{
    public GameObject gasEffect;
    public float fuelAmount = 20f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FuelSystem fuelSystem = other.GetComponent<FuelSystem>();
            if (fuelSystem != null)
            {
                fuelSystem.AddFuel(fuelAmount);
            }

            // Sonido combustible
            if (AudioManager.Instance != null)
                AudioManager.Instance.PlayAgarrarCombustible();

            if (gasEffect != null)
            {
                Vector3 spawnPos = transform.position;
                Instantiate(gasEffect, spawnPos, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }
}