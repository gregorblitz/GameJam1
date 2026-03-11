using UnityEngine;

public class AmmoPowerUp : MonoBehaviour
{
    public float fastFireRate = 0.1f;
    public float duration = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.ActivateAmmoPowerUp(fastFireRate, duration);
                Debug.Log("¡Munición especial activada!");
            }

            // Sonido municion
            if (AudioManager.Instance != null)
                AudioManager.Instance.PlayAgarrarMunicion();

            Destroy(gameObject);
        }
    }
}