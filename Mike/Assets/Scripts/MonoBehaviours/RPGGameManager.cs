using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGGameManager : MonoBehaviour
{
    // Reference to the camera manager class
    public RPGCameraManager cameraManager;

    // Reference to the spawn point designed for the player
    // Needed so the player can be re-spawned when they die
    public SpawnPoint playerSpawnPoint;

    // A variable used to access the singleton object
    public static RPGGameManager sharedInstance = null;

    // Ensure only a single instance of the RPGGameManager exists
    // It's possible to get multiple instances if multiple copies of the RPGGameManager exists in the Hierarchy
    // or if multiple copes are programmatically instantiated
    public void Awake()
    {
        // if sharedInstance has been initialized, but not to the current instance, then destroy it
        if (sharedInstance != null && sharedInstance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            sharedInstance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetupScene();        
    }

    public void SetupScene()
    {
        SpawnPlayer();
    }

    // Create a new player object if one does not already exist
    public void SpawnPlayer()
    {
        if (playerSpawnPoint != null)
        {
            GameObject player = playerSpawnPoint.SpawnObject();
            
            // Set the virtual camera to follow the player that was just spawned
            cameraManager.virtualCamera.Follow = player.transform;
        }
    }

    private void Update()
    {
        // Exit the application if the user presses the "escape" key
        // Does not work when playing from inside the Unity editor
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
