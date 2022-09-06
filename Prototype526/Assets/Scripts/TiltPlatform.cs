using System;
using UnityEngine;
using System.Collections;

public class TiltPlatform : MonoBehaviour {

    Vector3 playerPosition;
    Vector3 platformCenter;
    Vector3 centerToPlayer;
    [SerializeField] private float angleLimit = 30.0f;
    

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
        // Debug.Log("player position: " + playerPosition);
        // Debug.Log("center of platform: " + platformCenter);

        centerToPlayer = playerPosition - platformCenter; //creating vector from the center of platform to the player position
        // Debug.DrawLine(platformCenter, playerPosition, Color.white, 2.5f); //drawing the vector for debugging purposes

        //axis of rotation will be in the direction of the centerToPlayer direction
        transform.Rotate(centerToPlayer, centerToPlayer.magnitude * 0.035f); //this is rotating around an axis that is the direction of the vector from the center of the platform to our player. am just using 0.035 degrees because it seemed to be a good rate of rotation. am multiplying by the vector's magnitude so that it tilts more when we get closer to the edges
    }

    void OnCollisionExit(Collision collisionInfo) {
        // if (collisionInfo.gameObject.tag == "Player") {
            print("No longer in contact with " + collisionInfo.transform.name);
        // }
    }

	void OnCollisionEnter(Collision collisionInfo) {
        // if (collisionInfo.gameObject.tag == "Player") {
            print("Again in contact with " + collisionInfo.transform.name);
        // }
    }
}