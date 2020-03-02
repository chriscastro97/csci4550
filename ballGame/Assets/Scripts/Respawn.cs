using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject player;
    public GameObject respawnPoint;


    void update()
    {
        if (Input.GetKey("r"))
        {
            player.transform.position = respawnPoint.transform.position;
        }    
    }
}
