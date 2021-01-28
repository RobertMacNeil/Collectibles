using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    // gathers time collided
    public float timestamp;
    // time in seconds it takes to respawn
    private float respawn = 3.0f;

    // Update is called once per frame
    void Update()
    {
        // if the renderer is off
        if (!gameObject.GetComponent<Renderer>().enabled)
        {
            // if the change of time is greater then the respawn 
            if (Time.time - timestamp > respawn)
            {
                // re-enable components
                gameObject.GetComponent<Renderer>().enabled = true;
                gameObject.GetComponent<BoxCollider>().enabled = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // disable components
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            // sets timestamp to the current time of collision
            timestamp = Time.time;
        }
    }
}
