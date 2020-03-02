using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{ 
    private Rigidbody enemyRb;
    private GameObject player;
    public float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 lookDirection = (player.transform.position - transform.position);
        enemyRb.AddForce(lookDirection * speed);
    }
}
