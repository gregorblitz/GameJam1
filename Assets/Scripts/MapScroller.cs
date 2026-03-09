using UnityEngine;

public class MapScroller : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    public float velocidad = 300f;
    public float longitudChunk = 4000f;

    [Header("Chunks del Mapa")]
    public Transform[] chunks;

    void Update()
    {
        for (int i = 0; i < chunks.Length; i++)
        {
            // Mover hacia Z negativo (hacia el jugador)
            chunks[i].position += Vector3.back * velocidad * Time.deltaTime;

            // Cuando el chunk pasa al jugador, reciclarlo adelante
            if (chunks[i].position.z < -longitudChunk)
            {
                RecolocarChunk(i);
            }
        }
    }

    void RecolocarChunk(int indice)
    {
        float mayorZ = float.MinValue;
        for (int i = 0; i < chunks.Length; i++)
        {
            if (chunks[i].position.z > mayorZ)
                mayorZ = chunks[i].position.z;
        }

        Vector3 nuevaPos = chunks[indice].position;
        nuevaPos.z = mayorZ + longitudChunk;
        chunks[indice].position = nuevaPos;
    }
}