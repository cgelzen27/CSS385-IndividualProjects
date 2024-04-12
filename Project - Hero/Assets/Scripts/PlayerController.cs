using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public bool mouseControl = true;
    public float speed = 5.0f;
    public float turnSpeed = 30.0f;
    public float horizontalInput;
    public float forwardInput;
    public float fireCooldown;
    public GameObject projectilePrefab;
    private float lastShootTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.back * Time.deltaTime * turnSpeed * horizontalInput);

        if (mouseControl)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            transform.position = mousePosition;
        }
        else
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed * forwardInput);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            mouseControl = !mouseControl;
        }
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > lastShootTime + fireCooldown)
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
            lastShootTime = Time.time;
        }
    }
}
