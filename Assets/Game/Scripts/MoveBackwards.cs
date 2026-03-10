using UnityEngine;

public class MoveBackwards : MonoBehaviour
{

    public float speed = 300f;
    private float backBoundary = -3000f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        if (transform.position.z < backBoundary && gameObject.CompareTag("Obstaculo"))
        {
            Destroy(gameObject);
        }
    }
}
