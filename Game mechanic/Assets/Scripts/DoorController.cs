using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private bool isClosed = true;
    // Start is called before the first frame update
    void Start()
    {
        // Hook up the event
        EventManager.current.ToggleDoorEvent += DoorControll;
    }

    void DoorControll()
    {
        if (isClosed)
        {
            // open the area
            transform.Translate(new Vector3(1, 0, 0));
        }
        else
        {
            // close the area
            transform.Translate(new Vector3(1, 0, 0) * -1);
        }
        isClosed = !isClosed;
    }
    private void OnDisable()
    {
        // un-hook event
        EventManager.current.ToggleDoorEvent -= DoorControll;
    }
}
