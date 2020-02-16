using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    private float spawnDelay = 2;
    private float spawnInterval = 1.5f;

    //PlayerController refrence
    private PlayerControllerX playerController;

    // Start is called before the first frame update
    void Start()
    {
        //Get PlayerControllerX refrence
        playerController = GameObject.Find("Player").GetComponent<PlayerControllerX>();
        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);
    }

    // Spawn obstacles
    void SpawnObjects()
    {
        //When the game ends, stop spawning
        if (!playerController.gameOver)
        {
            Vector3 spawnLocation = new Vector3(30, UnityEngine.Random.Range(5, 14), 0);
            int randomIndex = UnityEngine.Random.Range(0, objectPrefabs.Length);

            Instantiate(objectPrefabs[randomIndex], spawnLocation, objectPrefabs[randomIndex].transform.rotation);

        }
        
    }
}
