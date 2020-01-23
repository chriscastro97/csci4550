using UnityEngine;
using Cinemachine;

public class RPGCameraManager : MonoBehaviour
{
    // A variable used to access the singleton object
    public static RPGCameraManager sharedInstance = null;

    // Reference to the virtual camera; set programmatically so no need to see it in unity editor
    [HideInInspector]
    public CinemachineVirtualCamera virtualCamera;

    public void Awake()
    {
        // Ensure only a single instance of the RPGGameManager exists
        if (sharedInstance != null && sharedInstance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            sharedInstance = this;
        }

        // Find the virtual camera object in the current scene
        GameObject vCamGameObject = GameObject.FindWithTag("VirtualCamera");

        // Get a reference to the virtual camera component of the virtual camera
        virtualCamera = vCamGameObject.GetComponent<CinemachineVirtualCamera>();
    }
}
