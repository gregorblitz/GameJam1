using UnityEngine;

public class GasPickup : MonoBehaviour
{
    public GameObject gasEffect; // Arrastra FX_Gas aqu� en el Inspector
    public float fuelAmount = 20f; // Cantidad de combustible que se agrega al recoger un gas
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FuelSystem fuelSystem = other.GetComponent<FuelSystem>();
            if (fuelSystem != null)
            {
                fuelSystem.AddFuel(fuelAmount);
            }
            if (gasEffect != null)
            {
                Vector3 spawnPos = transform.position; // Guarda posici�n antes de destruir
                Instantiate(gasEffect, spawnPos, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }
}