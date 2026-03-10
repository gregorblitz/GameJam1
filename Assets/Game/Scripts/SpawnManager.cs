using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject forceFieldOne;
    public GameObject forceFieldTwo;

    private Vector3 spawnPosOne = new Vector3(0, 150, 15);
    private Vector3 spawnPosTwo = new Vector3(0, 75, 500);
    private float startDelay = 5;
    private float repeatRate = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnForceFieldOne", startDelay, repeatRate);
        InvokeRepeating("SpawnForceFieldTwo", startDelay, repeatRate);
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
}
