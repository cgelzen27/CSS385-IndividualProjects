using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    // Singleton instance
    public static EventManager current;

    // All the events
    public event Action ToggleDoorEvent;

    // Implement the singleton
    private void Awake()
    {
        if (current == null)
        {
            current = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Events to be Raised
    public void StartToggleDoorEvent()
    {
        current.ToggleDoorEvent?.Invoke();
    }
}

