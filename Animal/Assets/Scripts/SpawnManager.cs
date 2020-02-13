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
    private float spawnRangeY = 0;
    public int roostersInWall = 4;

    //Rooster spawn conditions
    private float roosterSpawnRangeZ = 15;    

    //Timing variables
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        //Using the startDelay and spawnInterval variables, we limit the first time
        //An animalis spawned and an interval for the "SpawnRandomAnimal" method
        //InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Spawn a small wall of roosters from the Left side of the screen
            SpawnRoosterWallLeft(roostersInWall);
            SpawnRoosterWallRight(roostersInWall);
            SpawnRoosterWallBottom(roostersInWall);
            SpawnRoosterWallTop(roostersInWall);
        }
    }

    void SpawnRandomAnimal()
    {
        //Spawn a randomly generated animal using a random number and the animal array
        int animalIndex = UnityEngine.Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(UnityEngine.Random.Range(-spawnRangeX, spawnRangeX), spawnRangeY, UnityEngine.Random.Range(-spawnRangeZ, spawnRangeZ));
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);

        //TODO Change spawn function to spawn a 'wave' of enemies not just one
    }

    void SpawnRoosterWallLeft(int numOfRoosters)
    {
        //TODO get rid of hard coded string
        //Fix the rotation of the rooster
        FixRotation("left");

        for (int i = 0; i < roostersInWall; i++)
        {
            //Create spawn location
            Vector3 spawnPos = new Vector3(-19, 0, UnityEngine.Random.Range(-roosterSpawnRangeZ, roosterSpawnRangeZ));
            //Spawn Rooster
            Instantiate(animalPrefabs[2], spawnPos, animalPrefabs[2].gameObject.transform.rotation);
        }
        
    }

    void SpawnRoosterWallRight(int numOfRoosters)
    {
        //TODO get rid of hard coded string
        //Fix the rotation of the rooster
        Quaternion roosterRotation = FixRotation("right");

        for (int i = 0; i < roostersInWall; i++)
        {
            //Create spawn location
            Vector3 spawnPos = new Vector3(17, 0, UnityEngine.Random.Range(-2, 17));
            //Spawn Rooster
            Instantiate(animalPrefabs[2], spawnPos, roosterRotation);
        }

    }

    void SpawnRoosterWallBottom(int numOfRoosters)
    {
        //TODO get rid of hard coded string
        //Fix the rotation of the rooster
        Quaternion roosterRotation = FixRotation("bottom");

        for (int i = 0; i < roostersInWall; i++)
        {
            //Create spawn location
            Vector3 spawnPos = new Vector3(UnityEngine.Random.Range(-roosterSpawnRangeZ, roosterSpawnRangeZ), 0, -5);
            //Spawn Rooster
            Instantiate(animalPrefabs[2], spawnPos, roosterRotation);
        }

    }

    void SpawnRoosterWallTop(int numOfRoosters)
    {
        //TODO get rid of hard coded string
        //Fix the rotation of the rooster
        Quaternion roosterRotation = FixRotation("top");

        for (int i = 0; i < roostersInWall; i++)
        {
            //Create spawn location
            Vector3 spawnPos = new Vector3(UnityEngine.Random.Range(-roosterSpawnRangeZ, roosterSpawnRangeZ), 0, 20);
            //Spawn Rooster
            Instantiate(animalPrefabs[2], spawnPos, roosterRotation);
        }

    }

    private static Quaternion FixRotation(string dir)
    {
        if(dir == "top")
        {
            //South facing Quaternion
            return new Quaternion(0, 180, 0, 1);
        }

        else if(dir == "bottom")
        {
            //North facing Quaternion
            return new Quaternion(0, 0, 0, 1);
        }

        else if(dir == "right")
        {
            //West facing Quaternion
            return new Quaternion(0, 270, 0, 1);
        }

        else if(dir == "left")
        {
            //East facing Quaternion
            return new Quaternion(0, 90, 0, 1);
        }

        //Default
        return new Quaternion(0, 0, 0, 0);
    }

}
