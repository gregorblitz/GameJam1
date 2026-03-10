using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject forceFieldOne;
    public GameObject forceFieldTwo;
    public GameObject enemyPrefab; // OVNI Prefabs
    private Vector3 spawnPos = new Vector3(0, 0, 30); // Ajusta la Z según tu longitudChunk
    public GameObject gasoline;
    public GameObject life;

    private Vector3 spawnPosOne = new Vector3(0, 150, 15);
    private Vector3 spawnPosTwo = new Vector3(0, 75, 500);
    private float startDelay = 5;
    private float repeatRate = 10;
    private float minY = 30f;
    private float maxY = 600f;
    private float minZ = 0f;
    private float maxZ = 4000f;
    private float minLY = 20f;
    private float maxLY = 500f;
    private float minLZ = 15f;
    private float maxLZ = 3000f;

    void Start()
    {
        InvokeRepeating("SpawnForceFieldOne", startDelay, repeatRate);
        InvokeRepeating("SpawnForceFieldTwo", startDelay, repeatRate);
        InvokeRepeating("SpawnEnemy", startDelay, repeatRate);
        InvokeRepeating("SpawnGasoline", startDelay, repeatRate);
        InvokeRepeating("SpawnLife", startDelay, repeatRate);
    }

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
        // Genera una posición aleatoria en X
        float randomX = Random.Range(-20, 20); 
        Vector3 posAleatoria = new Vector3(randomX, 0, spawnPos.z);
        
        // Crea el OVNI en la escena
        Instantiate(enemyPrefab, posAleatoria, enemyPrefab.transform.rotation);
    } // <--- AQUÍ FALTABA ESTA LLAVE

    void SpawnGasoline()
    {
        float randomY = Random.Range(minY, maxY);
        float randomZ = Random.Range(minZ, maxZ);
        Vector3 spawnPosGas = new Vector3(0, randomY, randomZ);
        Instantiate(gasoline, spawnPosGas, gasoline.transform.rotation);
    }

    void SpawnLife()
    {
        float randomLY = Random.Range(minLY, maxLY);
        float randomLZ = Random.Range(minLZ, maxLZ);
        Vector3 spawnPosLife = new Vector3(0, randomLY, randomLZ);
        Instantiate(life, spawnPosLife, life.transform.rotation);
    }
}