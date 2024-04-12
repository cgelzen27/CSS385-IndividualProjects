using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private bool mouseControl = true;
    private float speed = 5.0f;
    private float turnSpeed = 360.0f;
    private float horizontalInput;
    private float forwardInput;
    private float fireCooldown;
    public GameObject projectilePrefab;
    private float lastShootTime;

    // Update is called once per frame
    void Update()
    {
        // Movement Controls 
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.back, Time.deltaTime * turnSpeed * horizontalInput);

        // Control Type Checker
        if (mouseControl)
        {
            // Scale the cursor position
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            transform.position = mousePosition;
        }
        else
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed * forwardInput);
        }

        // Changes the control type
        if (Input.GetKeyDown(KeyCode.M))
        {
            mouseControl = !mouseControl;
            // Event for updating the UI text for control type
            EventManager.current.StartChangeControlModeEvent();
        }
        
        // Quits or pauses the game
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }

        // Shoots egg to where the player is facing
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > lastShootTime + fireCooldown)    // cooldown implemented by checking the time and the time of the last bullet
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
            lastShootTime = Time.time;
            // Event for updating UI Text for Egg counter
            EventManager.current.StartIncreaseEggCounterEvent();
        }
    }
}
