using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    private Vector3 offset;
    public GameObject propeller;

    // Start is called before the first frame update
    void Start()
    {
      
        offset = plane.transform.position + (Vector3.right * 20);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = plane.transform.position + offset;
    }
}
