using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager current;

    public event Action EnemiesDestroyedEvent;
    public event Action ChangeControlModeEvent;
    public event Action EnemiesTouchEvent;
    public event Action IncreaseEggCounterEvent;
    public event Action DecreaseEggCounterEvent;

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

    // Update is called once per frame
    void Update()
    {
        
    }

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
