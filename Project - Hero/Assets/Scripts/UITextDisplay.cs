using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextDisplay : MonoBehaviour
{
    public Text controlType;
    public Text enemiesTouched;
    public Text eggsOnScreen;
    public Text enemiesDestroyed;

    public bool isMouseControl = true;
    private int numOfEnemyDestroyed = 0;
    private int numOfEnemyTouched = 0;
    private int eggCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.current.EnemiesDestroyedEvent += UpdateNumOfEnemyDestroyedCount;
        EventManager.current.ChangeControlModeEvent += ChangeControl;
        EventManager.current.EnemiesTouchEvent += UpdateNumOfEnemiesTouchedCount;
        EventManager.current.IncreaseEggCounterEvent += IncreaseEggCounter;
        EventManager.current.DecreaseEggCounterEvent += DecreaseEggCounter;
    }

    // Update is called once per frame
    void Update()
    {
        controlType.text = $"HERO:Drive({(isMouseControl ? "Mouse" : "Key")})";
        enemiesTouched.text = $"TouchedEnemy({numOfEnemyTouched})";
        eggsOnScreen.text = $"EGG: OnScreen({eggCount})";
        enemiesDestroyed.text = $"ENEMY Destroyed({numOfEnemyDestroyed})";

    }
    private void OnDisable()
    {
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
