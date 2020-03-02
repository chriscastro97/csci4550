using UnityEngine;
using System.Collections;

public class ButtonMovement : MonoBehaviour {

    //Is this object supposed to rotate?
    public bool rotation = false;
    //What is it rotating around?
    public Transform rotateAround;
    //How fast is it rotating?
    public float rotationSpeed = 1f;
    //Is the rotation clockwise or counter clockwise?
    public bool clockwiseRotation = true;
    //This will be set to the starting position of this object
    Vector3 startPos;
    //Is this object supposed to move?
    public bool movement = true;
    //What direction should it move? Caution: only up, down, left, right, forward and back is recognized
    public string direction = "up";
    //How far should it move?
    public float length = 1f;
    //How  it should  move?
    public float duration = 1f;
    //Should this object have a secondary movement?
    public bool secondaryMovement = true;
    // its second direction
    public string secondaryDirection = "up";
    //Its second length
    public float secLength = 1f;
    //Its second speed?
    public float secDuration = 1f;

	// Use this for initialization
	void Start () {
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        //Is it set to rotate?
        if (rotation)
        {
            //Clockwise ot counter clockwise?
            if (clockwiseRotation)
            {
                //It is rotating around: This object, on this axis, at this speed 
                transform.RotateAround(rotateAround.position, Vector3.forward, rotationSpeed * Time.deltaTime);
            }
            else
                transform.RotateAround(rotateAround.position, Vector3.back, rotationSpeed * Time.deltaTime);
        }

        //Is it set to move?
        if (movement == true)
        {
            //This creates the since wave that handles the movement of the object
            float alpha = Time.timeSinceLevelLoad / duration;
            float distance = length * Mathf.Sin(alpha);
            //Check what direction it should move
            switch (direction)
            {
                case "up":
                case "down":
                    //Move according to the sine wave
                    transform.position = startPos + Vector3.up * distance;
                    break;
                case "left":
                case "right":
                    transform.position = startPos + Vector3.left * distance;
                    break;
                case "forward":
                case "back":
                case "backward":
                    transform.position = startPos + Vector3.forward * distance;
                    break;
                default:
                    //A direction has not been picked or the direction is not one of the above
                Debug.Log("Invalid direction");
                    break;
            }

        }
        //Does this object have a secondary movement?
        if (secondaryMovement == true)
        {
            float beta = Time.timeSinceLevelLoad / secDuration;
            float secDistance = secLength * Mathf.Sin(beta);
            switch (secondaryDirection)
            {
                case "up":
                case "down":
                    transform.position = transform.position + Vector3.up * secDistance;
                    break;
                case "left":
                case "right":
                    transform.position = transform.position + Vector3.left * secDistance;
                    break;
                case "forward":
                case "back":
                case "backward":
                    transform.position = transform.position + Vector3.forward * secDistance;
                    break;
                default:
                    Debug.Log("Invalid secondary direction");
                    break;
            }

        }

	}
}
