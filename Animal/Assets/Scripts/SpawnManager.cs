using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    //Spawn conditions
    private float spawnRangeX = 20;
    private float spawnRangeZ = 20;

    //Timing variables
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        //Using the startDelay and spawnInterval variables, we limit the first time
        //An animalis spawned and an interval for the "SpawnRandomAnimal" method
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        //TODO Define number of animals in wave here
        //TODO Define different wave patterns here
    }

    void SpawnRandomAnimal()
    {
        //Spawn a randomly generated animal using a random number and the animal array
        int animalIndex = UnityEngine.Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(UnityEngine.Random.Range(-spawnRangeX, spawnRangeX), 0, 
         UnityEngine.Random.Range(-spawnRangeZ, spawnRangeZ));
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);

        //TODO Change spawn function to spawn a 'wave' of enemies not just one
    }
}
