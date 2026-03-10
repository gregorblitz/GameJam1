using UnityEngine;

public class Bala : MonoBehaviour
{
    public float speed = 1500f;
    public float lifeTime = 3f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Space.World para ignorar la rotación del avión
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
    }
}