using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    // Singleton instance
    public static EventManager current;

    // All the events
    public event Action EnemiesDestroyedEvent;
    public event Action ChangeControlModeEvent;
    public event Action EnemiesTouchEvent;
    public event Action IncreaseEggCounterEvent;
    public event Action DecreaseEggCounterEvent;

    // Implement the singleton
    private void Awake()
    {
        if(current == null)
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
    public void StartEnemiesDestroyedEvent()
    {
        current.EnemiesDestroyedEvent?.Invoke();
    }
    public void StartChangeControlModeEvent()
    {
        current.ChangeControlModeEvent?.Invoke();
    }
    public void StartIncreaseEggCounterEvent() 
    { 
        current.IncreaseEggCounterEvent?.Invoke();
    }
    public void StartDecreaseEggCounterEvent()
    {
        current?.DecreaseEggCounterEvent?.Invoke();
    }
    public void StartEnemiesTouchEvent()
    {
        current.EnemiesTouchEvent?.Invoke();
    }
}
