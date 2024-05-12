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
            transform.Translate(new Vector2(0, 3));
        }
        else
        {
            // close the area
            transform.Translate(new Vector2(0, 3) * -1);
        }
        isClosed = !isClosed;
    }
    private void OnDisable()
    {
        // un-hook event
        EventManager.current.ToggleDoorEvent -= DoorControll;
    }
}
