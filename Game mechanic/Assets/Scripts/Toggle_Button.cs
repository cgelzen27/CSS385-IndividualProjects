using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle_Button : MonoBehaviour
{
    private bool isToggled = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Change button visually
        if (isToggled)
            transform.localScale = new Vector3(transform.localScale.x, 0.5f);
        else
            transform.localScale = new Vector3(transform.localScale.x, 0.1f);

        // Initiate the action for the event
        EventManager.current.StartToggleDoorEvent();
        isToggled = !isToggled;
    }
}