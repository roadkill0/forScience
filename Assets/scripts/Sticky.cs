using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticky : MonoBehaviour
{
    private Vector3 lastPlatformPosition;
    private GameObject player;

    private void Start()
    {
        lastPlatformPosition = transform.position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            player = collision.gameObject;
            lastPlatformPosition = transform.position;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            player = null;
        }
    }
    private void Update()
    {
        if (player != null)
        {
            // Calculate how much the platform has moved since the last frame
            Vector3 platformMovement = transform.position - lastPlatformPosition;

            // Apply this movement offset to the player's position
            player.transform.position += platformMovement;
        }
        //update the last position for the next frame
        lastPlatformPosition = transform.position;
    }
}