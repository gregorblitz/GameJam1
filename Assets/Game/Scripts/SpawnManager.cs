using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject forceFieldOne;
    public GameObject forceFieldTwo;
    public GameObject gasoline;
    public GameObject life;
    public GameObject ammo;

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

    private float minAY = 10f;
    private float maxAY = 400f;
    private float minAZ = 30f;
    private float maxAZ = 2000f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnForceFieldOne", startDelay, repeatRate);
        InvokeRepeating("SpawnForceFieldTwo", startDelay, repeatRate);
        InvokeRepeating("SpawnGasoline", startDelay, repeatRate);
        InvokeRepeating("SpawnLife", startDelay, repeatRate);
        InvokeRepeating("SpawnAmmo", startDelay, repeatRate);
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

    void SpawnAmmo()
    {
        float randomAY = Random.Range(minAY, maxAY);
        float randomAZ = Random.Range(minAZ, maxAZ);

        Vector3 spawnPosAmmo = new Vector3(0, randomAY, randomAZ);

        Instantiate(ammo, spawnPosAmmo, ammo.transform.rotation);
    }
}
