using UnityEngine;

public class Bala : MonoBehaviour
{
    public float speed = 50f;
    public float lifeTime = 3f;

    void Start()
    {
        // Destruye la bala despues de 3 segundos
        // para que no se sature memoria
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // La bala siempre avanza hacia adelante
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}