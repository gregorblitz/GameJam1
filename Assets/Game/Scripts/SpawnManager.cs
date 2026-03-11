using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject forceFieldOne;
    public GameObject forceFieldTwo;
    public GameObject enemyPrefab; // OVNI Prefabs
    private Vector3 spawnPos = new Vector3(0, 0, 30); // Ajusta la Z según tu longitudChunk
    public GameObject gasoline;
    public GameObject life;
    public GameObject ammo;

    //private Vector3 spawnPosOne = new Vector3(0, 150, 15);
    //private Vector3 spawnPosTwo = new Vector3(0, 75, 500);
    private float startDelay = 5;
    private float repeatRate = 10;

    private float minX = -150f;
    private float maxX = 150f;
    private float minY = 30f;
    private float maxY = 600f;
    private float minZ = 0f;
    private float maxZ = 4000f;

    private float minLY = 20f;
    private float maxLY = 500f;
    private float minLZ = 15f;
    private float maxLZ = 3000f;

    private float minAY = 10f;
    private float maxAY = 400f;
    private float minAZ = 30f;
    private float maxAZ = 2000f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnForceFieldOne", startDelay, repeatRate);
        InvokeRepeating("SpawnForceFieldTwo", startDelay, repeatRate);
        InvokeRepeating("SpawnEnemy", startDelay, repeatRate);
        InvokeRepeating("SpawnGasoline", startDelay, repeatRate);
        InvokeRepeating("SpawnLife", startDelay, repeatRate);
        InvokeRepeating("SpawnAmmo", startDelay, repeatRate);
    }

    void Update()
    {
        
    }

    void SpawnForceFieldOne()
    {
        float randomFOX = Random.Range(minX, maxX);
        float randomFOY = Random.Range(minY, maxY);
        float randomFOZ = Random.Range(minZ, maxZ);

        Vector3 spawnPosOne = new Vector3(randomFOX, randomFOY, randomFOZ);

       Instantiate(forceFieldOne, spawnPosOne, forceFieldOne.transform.rotation);
    }   

    void SpawnForceFieldTwo()
    {
        float randomFTX = Random.Range(minX, maxX);
        float randomFTY = Random.Range(minY, maxY);
        float randomFTZ = Random.Range(minZ, maxZ);

        Vector3 spawnPosTwo = new Vector3(randomFTX, randomFTY, randomFTZ);

        Instantiate(forceFieldTwo, spawnPosTwo, forceFieldTwo.transform.rotation);
    }

    void SpawnEnemy()
    {
    // Aumenta el rango de -15, 15 a uno que cubra todo el carril
        float randomX = Random.Range(-25, 25); 
        Vector3 posAleatoria = new Vector3(randomX, 1, 100); 
        Instantiate(enemyPrefab, posAleatoria, enemyPrefab.transform.rotation);
    } 

    void SpawnGasoline()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        float randomZ = Random.Range(minZ, maxZ);

        Vector3 spawnPosGas = new Vector3(randomX, randomY, randomZ);

        Instantiate(gasoline, spawnPosGas, gasoline.transform.rotation);
    }

    void SpawnLife()
    {
        float randomLX = Random.Range(minX, maxX);
        float randomLY = Random.Range(minY, maxY);
        float randomLZ = Random.Range(minZ, maxZ);

        Vector3 spawnPosLife = new Vector3(randomLX, randomLY, randomLZ);

        Instantiate(life, spawnPosLife, life.transform.rotation);
    }

    void SpawnAmmo()
    {
        float randomAY = Random.Range(minAY, maxAY);
        float randomAZ = Random.Range(minAZ, maxAZ);

        Vector3 spawnPosAmmo = new Vector3(0, randomAY, randomAZ);

        Instantiate(ammo, spawnPosAmmo, ammo.transform.rotation);
    }
    
   
}
