using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Weapon : MonoBehaviour
{
    // Reference to the ammo prefab, used to create new ammo objects
    public GameObject ammoPrefab;

    // The ammo pool; static means only one copy will exist
    static List<GameObject> ammoPool;

    // Number of objects to pre-instantiate in the pool
    public int poolSize;

    // Velocity of ammo fired from the weapon
    public float weaponVelocity;

    // Is the player currently firing the slingshot
    bool isFiring;

    // Reference to an animator
    [HideInInspector]
    public Animator animator;

    // Reference to the camera
    Camera localCamera;

    // Slope of the the two lines used in quadrant calculation for firing animations
    float positiveSlope;
    float negativeSlope;

    // Enum to describe the direction the player is firing in
    enum Quadrant
    {
        East,
        South,
        West,
        North
    }

    // Enum to describe which slope line is used for quadrant comparisons
    enum SlopeLine
    {
        Positive,
        Negative
    }

    // Called when the script is being loaded
    private void Awake()
    {
        if (ammoPool == null)
        {
            // Create the pool
            ammoPool = new List<GameObject>();
        }

        // Loop to create ammo objects and add to the pool
        for (int i = 0; i < poolSize; i++)
        {
            GameObject ammoObject = Instantiate(ammoPrefab);
            ammoObject.SetActive(false);
            ammoPool.Add(ammoObject);
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        isFiring = false;
        localCamera = Camera.main;

        // Create four Vectors to represent the four corners of the screen
        Vector2 lowerLeft = localCamera.ScreenToWorldPoint(new Vector2(0, 0));
        Vector2 upperRight = localCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Vector2 upperLeft = localCamera.ScreenToWorldPoint(new Vector2(0, Screen.height));
        Vector2 lowerRight = localCamera.ScreenToWorldPoint(new Vector2(Screen.width, 0));

        // Calculate slopes of two lines to disect the screen into four quadrants
        // This is to help determine what direction the player should face when the mouse is clicked
        positiveSlope = GetSlope(lowerLeft, upperRight);
        negativeSlope = GetSlope(upperLeft, lowerRight);
    }

    // Calculate the slope of a line, given two (x,y) points
    float GetSlope(Vector2 pointOne, Vector2 pointTwo)
    {
        return (pointTwo.y - pointOne.y) / (pointTwo.x - pointOne.x);
    }

    // Called when the gameobject is destroyed
    private void OnDestroy()
    {
        ammoPool = null;
    }

    // Called each frame
    private void Update()
    {
        // Check to see if user has clicked the mouse to fire the slingshot
        // Parameter 0 checks for left mouse button; 1 checks for right
        if (Input.GetMouseButtonDown(0))
        {
            isFiring = true;
            FireAmmo();
        }

        UpdateState();
    }

    // Update animation state for whether or not the player is firing
    private void UpdateState()
    {
        if (isFiring)
        {
            Vector2 quadrantVector;
            Quadrant quadEnum = GetQuadrant();

            switch (quadEnum)
            {
                case Quadrant.East:
                    quadrantVector = new Vector2(1.0f, 0.0f);
                    break;
                case Quadrant.South:
                    quadrantVector = new Vector2(0.0f, -1.0f);
                    break;
                case Quadrant.West:
                    quadrantVector = new Vector2(-1.0f, 1.0f);
                    break;
                case Quadrant.North:
                    quadrantVector = new Vector2(0.0f, 1.0f);
                    break;
                default:
                    quadrantVector = new Vector2(0.0f, 0.0f);
                    break;
            }

            animator.SetBool("isFiring", true);

            animator.SetFloat("fireXDir", quadrantVector.x);
            animator.SetFloat("fireYDir", quadrantVector.y);

            isFiring = false;
        }
        else
        {
            animator.SetBool("isFiring", false);
        }
    }    

    // Determines if the inputPosition is above a given sloped line, going through the player position
    // compare = determine if to compare against the positive or negative sloped line
    bool AboveSlopeLine(SlopeLine compare, Vector2 inputPosition)
    {  
        Vector2 playerPosition = gameObject.transform.position;
        Vector2 mousePosition = localCamera.ScreenToWorldPoint(inputPosition);
        float slopeOfLineToCompare = compare == SlopeLine.Positive ? positiveSlope : negativeSlope;

        // "Draw" (virtually) a line which goes through the player position, and has the same slope as the slopeOfLineToCompare
        // Calculate where this line intercepts the y-axis
        float yIntercept = playerPosition.y - (slopeOfLineToCompare * playerPosition.x);

        // Calculate a second line, which runs through the mouse-click position and is parallel to the player line
        float inputIntercept = mousePosition.y - (slopeOfLineToCompare * mousePosition.x);

        // Compare where the mouse line and player lines cross the y-axis to determine if mouse line is above player line
        return inputIntercept > yIntercept;



        // Alternate method:
        // For a given point (x, y), if 𝑦 > m𝑥 + 𝑏, then the point is above the line
        // m = slope of the line, and b = the point where the line crosses the y-axis
        // return mousePosition.y > slopeOfLineToCompare * mousePosition.x + yIntercept;
    }

    // Determines in which quadrant (north, south, east, or west) around the player that the mouse was clicked
    Quadrant GetQuadrant()
    {
        bool abovePositiveSlopeLine = AboveSlopeLine(SlopeLine.Positive, Input.mousePosition);
        bool aboveNegativeSlopeLine = AboveSlopeLine(SlopeLine.Negative, Input.mousePosition);

        // Mouse click is "west, north-west, or north" of the player
        if (abovePositiveSlopeLine)
        {
            if (aboveNegativeSlopeLine)
                return Quadrant.North;
            else
                return Quadrant.West;
        }
        // Mouse click is "south, south-east, or east" of the player
        else 
        {
            if (aboveNegativeSlopeLine)
                return Quadrant.East;
            else
                return Quadrant.South;
        }
    }

    // Retrieves and returns an activated AmmoObject from the object pool
    // Location: where to place the retrieved AmmoObject
    GameObject SpawnAmmo(Vector3 location)
    {
        foreach (GameObject ammo in ammoPool)
        {
            // Check to see if the current object is inactive
            if (ammo.activeSelf == false)
            {
                // Activate it
                ammo.SetActive(true);

                // Set it's location
                ammo.transform.position = location;

                return ammo;
            }
        }

        // Return null if all objects in the pool are currently being used
        return null;
    }

    // Responsible for moving the AmmoObject from the spawned location to the endpoint where the mouse was clicked
    private void FireAmmo()
    {
        // Convert the mouse position from screen space to world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Get a new ammo object located at the weapon's current position
        GameObject ammo = SpawnAmmo(transform.position);

        // Make sure you got an ammo object
        if (ammo != null)
        {
            // Get reference to the arc script
            Arc arcScript = ammo.GetComponent<Arc>();

            // Calculate the amount of time for ammo travel
            // Example: if velocity is 2, then 1/2 = 0.5 or a half second to travel across the screen
            float travelDuration = 1.0f / weaponVelocity;

            StartCoroutine(arcScript.TravelArc(mousePosition, travelDuration));
        }
    }
}
