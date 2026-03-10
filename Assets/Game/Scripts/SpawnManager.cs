using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject forceFieldOne;
    public GameObject forceFieldTwo;
    public GameObject enemyPrefab; // OVNI  Prefabs
    private Vector3 spawnPos = new Vector3(0, 0, 30); // Ajusta la Z según tu longitudChunk
    private Vector3 spawnPosOne = new Vector3(0, 150, 15);
    private Vector3 spawnPosTwo = new Vector3(0, 75, 500);
    private float startDelay = 5;
    private float repeatRate = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnForceFieldOne", startDelay, repeatRate);
        InvokeRepeating("SpawnForceFieldTwo", startDelay, repeatRate);
        InvokeRepeating("SpawnEnemy", startDelay, repeatRate);//holmes
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnForceFieldOne()
    {
        Instantiate(forceFieldOne, spawnPosOne, forceFieldOne.transform.rotation);
    }   

    void SpawnForceFieldTwo()
    {
        Instantiate(forceFieldTwo, spawnPosTwo, forceFieldTwo.transform.rotation);
    }
    void SpawnEnemy()
    {
        // Genera una posición aleatoria en X para que no siempre aparezcan en el centro
        float randomX = Random.Range(-20, 20); 
        Vector3 posAleatoria = new Vector3(randomX, 0, spawnPos.z);
        
        // Crea el OVNI en la escena
        Instantiate(enemyPrefab, posAleatoria, enemyPrefab.transform.rotation);
    }
}
