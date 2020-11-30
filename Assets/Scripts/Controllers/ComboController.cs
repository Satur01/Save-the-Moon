using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboController : MonoBehaviour
{
    public Image comboBar;

    public ComboLevels currentLevel;
    public ComboLevelsScriptable ComboStats;

    public int streakEnemies;

    public float maxTime, timeLeft;

    public bool comboRunning;


    // Start is called before the first frame update
    void Start()
    {
        timeLeft = ComboStats.levelSettings[0].timeLimit;
        maxTime = timeLeft;
        currentLevel = ComboLevels.D;
        comboRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (comboRunning)
        {
            if (timeLeft >= 0)
            {
                timeLeft -= Time.deltaTime;
                comboBar.fillAmount = timeLeft / maxTime;
            }
            else
            {
                if (currentLevel == ComboLevels.D)
                {
                    ResetCombo();
                }
                else
                {
                    LevelReduction();
                }
            }
        }
    }

    private void LevelReduction()
    {
        currentLevel -= 1;
        int index = (int)currentLevel;
        maxTime = ComboStats.levelSettings[index].timeLimit;
        timeLeft = maxTime;
    }

    private void ResetCombo()
    {
        streakEnemies = 0;
        timeLeft = 0;
        comboRunning = false;
    }
}
