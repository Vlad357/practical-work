using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SaveTheVillage
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        [Header("Statistics")]
        public int productedEat;
        public int usedEat;
        public int productedWarriors;
        public int fallenWarriors;
        public int productedPeasants;
        public int cyclesLived;

        public StatisticsTable statsLose;
        public StatisticsTable statsWin;

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


        [Header("victory conditions")]

        public GameObject winGamePanel;
        public GameObject loseGamePanel;

        public int peasantConditionsCount;
        public int eatConditionsCount;

        public int EatCount
        {
            get
            {
                return Convert.ToInt32(eatCounter.text);
            }
            set
            {
                eatCounter.text = value.ToString();
                if (value >= eatConditionsCount)
                {
                    eatVictoryConditions = true;
                    CheckVictory();
                }
                if (value >= 1)
                {
                    peasantCreate.interactable = true;
                    warriorCreate.interactable = true;
                }
                if (value <= 0)
                {
                    peasantCreate.interactable = false;
                    warriorCreate.interactable = false;
                }
            }
        }

        private bool peasantVictoryConditions = false;
        private bool eatVictoryConditions = false;

        public bool CheckPeasant()
        {
            int peasantCountValue = Convert.ToInt32(peasantCounter.text);
            if (peasantCountValue > 0)
            {
                if (peasantCountValue >= peasantConditionsCount)
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

        public void CreateWarriorsEvent()
        {
            productedWarriors++;
        }
        public void CreatePeasantsEvent()
        {
            productedPeasants++;
        }

        public void CreatePerson(TextMeshProUGUI personCounter)
        {
            int personCount = Convert.ToInt32(personCounter.text);
            int eatCount = EatCount;
            personCounter.text = (personCount + 1).ToString();
            eatCount -= 1;
            EatCount = eatCount > 0 ? eatCount : 0;
            usedEat++;
        }

        public void EatCreate()
        {
            int eatCount = EatCount;
            int peasantCount = Convert.ToInt32(peasantCounter.text);
            eatCount += peasantCount * createEatCount;
            productedEat += peasantCount * createEatCount;
            EatCount = eatCount;
        }

        public void UseEat()
        {
            int eatCount = Convert.ToInt32(eatCounter.text);
            int warriorsCount = Convert.ToInt32(warriorsCounter.text);
            int resultEat = eatCount - warriorsCount;
            EatCount = resultEat > 0 ? resultEat : 0;
            usedEat += warriorsCount;
        }

        public void GameCycle()
        {
            int currentCycle = Convert.ToInt32(currentCycleText.text) + 1;
            currentCycleText.text = currentCycle.ToString();
            cyclesBeforeRaid.text = (saveCycles - currentCycle).ToString();
            cyclesLived++;

            if (saveCycles - currentCycle <= 0)
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

            fallenWarriors += enemyCount;
        }

        public void RestartGame(GameObject panel)
        {
            panel.SetActive(false);

            peasantCounter.text = peasantDefaultCount.ToString();
            warriorsCounter.text = warriorsDefaultCount.ToString();
            enemyCountInNextWave.text = enemyDefaultCountInNextWave.ToString();
            EatCount = eatDefaultCount;


            peasantVictoryConditions = false;
            eatVictoryConditions = false;

            productedEat = 0;
            usedEat = 0;
            productedWarriors = 0;
            fallenWarriors = 0;
            productedPeasants = 0;
            cyclesLived = 0;

            Time.timeScale = 1;
        }

        public void SetTimeScale(float timeScale)
        {
            Time.timeScale = timeScale;
        }

        public void RevertAudioListner(AudioListener audioListener)
        {
            audioListener.enabled = !audioListener.enabled;
        }

        private void CheckVictory()
        {
            if (eatVictoryConditions && peasantVictoryConditions)
            {
                winGamePanel.SetActive(true);
                SetStatistics(statsWin);
                Time.timeScale = 0;
            }
        }

        private string RuinOfTheVillage()
        {
            loseGamePanel.SetActive(true);
            SetStatistics(statsLose);
            Time.timeScale = 0;
            return "0";
        }

        private void SetStatistics(StatisticsTable table)
        {
            table.SetStatistics(productedEat, usedEat, productedWarriors, 
                fallenWarriors, productedPeasants, cyclesLived);
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

}