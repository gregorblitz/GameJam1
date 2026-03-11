using UnityEngine;

public class MoveBackwards : MonoBehaviour
{

    public float speed = 300f;
    private float backBoundary = -3000f;
    private PlayerController player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);

        if (transform.position.z < backBoundary && gameObject.CompareTag("Obstaculo"))
        {
            Destroy(gameObject);
        }
        if (transform.position.z < backBoundary && gameObject.CompareTag("Gas"))
        {
            Destroy(gameObject);
        }
        if (transform.position.z < backBoundary && gameObject.CompareTag("Life"))
        {
            Destroy(gameObject);
        }
        if (transform.position.z < backBoundary && gameObject.CompareTag("Enemigo"))
        {
            if (player != null){    
                player.LoseLife();
                Destroy(gameObject);
            } else
            {
                Debug.LogWarning("PlayerController no encontrado desde MoveBackwards");
            }
        }
    }
}
