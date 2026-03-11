using UnityEngine;

public class LifePickup : MonoBehaviour
{
    // Ajusta según tu sistema de vidas
    public int lifeAmount = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Aquí conectas con tu sistema de vidas cuando lo tengas
            // Ejemplo: other.GetComponent<HealthSystem>()?.AddLife(lifeAmount);

            // Sonido vida
            if (AudioManager.Instance != null)
                AudioManager.Instance.PlayAgarrarVida();

            Debug.Log("¡Vida recogida!");
            Destroy(gameObject);
        }
    }
}