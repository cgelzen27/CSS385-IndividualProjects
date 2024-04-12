using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Set up the boundaries
    private float verticalBound = 10.0f;
    private float horizontalBound = 16.0f;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > verticalBound || transform.position.y < -verticalBound ||
            transform.position.x > horizontalBound || transform.position.x < -horizontalBound)
        {
            // Destroy the projectile and Raise the event
            Destroy(gameObject);
            EventManager.current.StartDecreaseEggCounterEvent();
        }
    }
}
