using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextDisplay : MonoBehaviour
{
    // Reference to UI objects
    public Text controlType;
    public Text enemiesTouched;
    public Text eggsOnScreen;
    public Text enemiesDestroyed;

    // Initial values
    public bool isMouseControl = true;
    private int numOfEnemyDestroyed = 0;
    private int numOfEnemyTouched = 0;
    private int eggCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        // Hook up all the events
        EventManager.current.EnemiesDestroyedEvent += UpdateNumOfEnemyDestroyedCount;
        EventManager.current.ChangeControlModeEvent += ChangeControl;
        EventManager.current.EnemiesTouchEvent += UpdateNumOfEnemiesTouchedCount;
        EventManager.current.IncreaseEggCounterEvent += IncreaseEggCounter;
        EventManager.current.DecreaseEggCounterEvent += DecreaseEggCounter;
    }

    // Update is called once per frame
    void Update()
    {
        // Keep changing the UI text based on the updated values
        controlType.text = $"HERO:Drive({(isMouseControl ? "Mouse" : "Key")})";
        enemiesTouched.text = $"TouchedEnemy({numOfEnemyTouched})";
        eggsOnScreen.text = $"EGG: OnScreen({eggCount})";
        enemiesDestroyed.text = $"ENEMY Destroyed({numOfEnemyDestroyed})";

    }
    private void OnDisable()
    {
        // UnHooks the event when object becomes inactive
        EventManager.current.EnemiesDestroyedEvent -= UpdateNumOfEnemyDestroyedCount;
        EventManager.current.ChangeControlModeEvent -= ChangeControl;
        EventManager.current.EnemiesTouchEvent -= UpdateNumOfEnemiesTouchedCount;
        EventManager.current.IncreaseEggCounterEvent -= IncreaseEggCounter;
        EventManager.current.DecreaseEggCounterEvent -= DecreaseEggCounter;
    }
    private void UpdateNumOfEnemyDestroyedCount()
    {
        numOfEnemyDestroyed++;
    }
    private void UpdateNumOfEnemiesTouchedCount()
    {
        numOfEnemyTouched++;
    }
    private void ChangeControl()
    {
        isMouseControl = !isMouseControl;
    }
    private void IncreaseEggCounter()
    {
        eggCount++;
    }
    private void DecreaseEggCounter()
    {
        eggCount--;
    }
}
