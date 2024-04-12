using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float verticalBound = 10.0f;
    private float horizontalBound = 16.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > verticalBound || transform.position.y < -verticalBound ||
            transform.position.x > horizontalBound || transform.position.x < -horizontalBound)
        {
            Destroy(gameObject);
        }
    }
}
