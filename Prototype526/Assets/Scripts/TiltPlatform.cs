using UnityEngine;
using System.Collections;

public class TiltPlatform : MonoBehaviour {

    Vector3 playerPosition;
    Vector3 platformCenter;
    Vector3 centerToPlayer;

    // Use this for initialization
    void Start () {
        platformCenter = GameObject.FindGameObjectWithTag("Platform").transform.position;
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        //logging initial position of player and platform, not sure why the platform is already rotating if they are the same
        Debug.Log("player position: " + playerPosition);
        Debug.Log("center of platform: " + platformCenter);
    }
    
    // Update is called once per frame
    void Update () {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        Debug.Log("player position: " + playerPosition);
        Debug.Log("center of platform: " + platformCenter);

        centerToPlayer = playerPosition - platformCenter; //creating vector from the center of platform to the player position
        Debug.DrawLine(platformCenter, playerPosition, Color.white, 2.5f); //drawing the vector for debugging purposes

        //axis of rotation will be in the direction of the centerToPlayer direction
        if (playerPosition != platformCenter) { //was trying to stop the platform moving when we havent moved the player
            transform.Rotate(centerToPlayer, 0.075f); //this is rotating around an axis that is the direction of the vector from the center of the platform to our player. am just using 0.075 degrees because it seemed to be a good rate of rotation
        }
        
    }
}