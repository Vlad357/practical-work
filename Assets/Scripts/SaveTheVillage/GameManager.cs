using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("victory conditions")]

    public GameObject winGamePanel;
    public GameObject loseGamePanel;

    public int peasantConditionsCount;
    public int eatConditionsCount;

    private bool peasantVictoryConditions = false;
    private bool eatVictoryConditions = false;

    [Header("counters")]
    public TextMeshProUGUI peasantCounter;
    public TextMeshProUGUI warriorsCounter;
    public TextMeshProUGUI eatCounter;
    public TextMeshProUGUI enemyCountInNextWave;

    public int peasantDefaultCount;
    public int warriorsDefaultCount;
    public int eatDefaultCount;
    public int enemyDefaultCountInNextWave;

    public int createEatCount;

    [Header("timers")]
    public Timer eatUseTimer;
    public Timer eatCreateTimer;

    [Header("Cycles info")]
    public int saveCycles;
    public TextMeshProUGUI currentCycleText;
    public TextMeshProUGUI cyclesBeforeRaid;

    [Header("Buttons")]
    public Button peasantCreate;
    public Button warriorCreate;
    public bool CheckPeasant()
    {
        int peasantCountValue = Convert.ToInt32(peasantCounter.text);
        if ( peasantCountValue > 0)
        {
            if(peasantCountValue >= peasantConditionsCount)
            {
                peasantVictoryConditions = true;
                CheckVictory();
            }
            return true;
        }
        return false;
    }

    public bool CheckWarriors()
    {
        if (Convert.ToInt32(warriorsCounter.text) > 0)
            return true;
        return false;
    }

    public void CreatePerson( TextMeshProUGUI personCounter)
    {
        int personCount = Convert.ToInt32(personCounter.text);
        int eatCount = Convert.ToInt32(eatCounter.text);
        personCounter.text = (personCount + 1).ToString();
        eatCount -= 1;
        eatCounter.text = eatCount > 0 ? eatCount.ToString() : 0.ToString();
    }

    public void EatCreate()
    {
        int eatCount = Convert.ToInt32(eatCounter.text);
        int peasantCount = Convert.ToInt32(peasantCounter.text);
        eatCount += peasantCount * createEatCount;
        eatCounter.text = eatCount.ToString();
        if(eatCount >= eatConditionsCount)
        {
            eatVictoryConditions = true;
            CheckVictory();
        }
        if (eatCount >= 1)
        {
            peasantCreate.interactable = true;
            warriorCreate.interactable = true;
        }
    }

    public void UseEat()
    {
        int eatCount = Convert.ToInt32(eatCounter.text);
        int warriorsCount = Convert.ToInt32(warriorsCounter.text);
        int resultEat = eatCount - warriorsCount;
        eatCounter.text = resultEat > 0 ? resultEat.ToString() : 0.ToString();


        if (resultEat <= 0)
        {
            peasantCreate.interactable = false;
            warriorCreate.interactable = false;
        }
        if (resultEat >= 1)
        {
            peasantCreate.interactable = true;
            warriorCreate.interactable = true;
        }
    }

    public void GameCycle()
    {
        int currentCycle = Convert.ToInt32(currentCycleText.text) + 1;
        currentCycleText.text = currentCycle.ToString();
        cyclesBeforeRaid.text = (saveCycles - currentCycle).ToString();

        if(saveCycles - currentCycle <= 0)
        {
            Raid();
        }
    }

    public void Raid()
    {
        int warriorsCount = Convert.ToInt32(warriorsCounter.text);
        int enemyCount = Convert.ToInt32(enemyCountInNextWave.text);
        
        int resultWarrior = warriorsCount - enemyCount;

        warriorsCounter.text = resultWarrior >= 0 ? resultWarrior.ToString() : RuinOfTheVillage();

        enemyCount = Convert.ToInt32(enemyCount + 1);

        enemyCountInNextWave.text = enemyCount.ToString();
    }

    public void RestartGame(GameObject panel)
    {
        panel.SetActive(false);

        peasantCounter.text = peasantDefaultCount.ToString();
        warriorsCounter.text = warriorsDefaultCount.ToString();
        eatCounter.text = eatDefaultCount.ToString();
        enemyCountInNextWave.text = enemyDefaultCountInNextWave.ToString();

        peasantVictoryConditions = false;
        eatVictoryConditions = false;

        Time.timeScale = 1;
    }

    private void CheckVictory()
    {
        if(eatVictoryConditions && peasantVictoryConditions)
        {
            winGamePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private string RuinOfTheVillage()
    {
        loseGamePanel.SetActive(true);
        Time.timeScale = 0;
        return "0";
    }

    private void Initialize()
    {
        eatCreateTimer.ruleTimer = CheckPeasant;
        eatUseTimer.ruleTimer = CheckWarriors;
        cyclesBeforeRaid.text = saveCycles.ToString();
    }

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance == this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        Initialize();
    }
}
