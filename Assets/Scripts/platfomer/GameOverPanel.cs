using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer
{
    public class GameOverPanel : MonoBehaviour
    {
        public GameObject gameOverPanelObject;

        public GameObject restertTheLevelButton;
        public GameObject nextLevelButton;
        public GameObject restartThisGameButton;

        public TextMeshProUGUI textOnPanel;

        public TextMeshProUGUI takenDamageStatisticText;
        public TextMeshProUGUI damageDoneStatisticText;
        public TextMeshProUGUI coinsStatisticText;

        public int startLevelId = 1;

        private Statistic _playerStatistic;

        public Statistic PlayerStatistic
        {
            get
            {
                return _playerStatistic;
            }
            set
            {
                _playerStatistic = value;
                takenDamageStatisticText.text = _playerStatistic.takenDamage.ToString();
                damageDoneStatisticText.text = _playerStatistic.damageDone.ToString();
                coinsStatisticText.text = _playerStatistic.coins.ToString();
            }
        }

        public void Show(bool isWin)
        {
            if (isWin)
            {
                textOnPanel.text = "You won!";
                switch (SceneManager.GetActiveScene().buildIndex)
                {
                    case 5:
                        restartThisGameButton.SetActive(true);
                        break;
                    default:
                        nextLevelButton.SetActive(true);
                        break;
                }
            }
            else
            {
                textOnPanel.text = "You lose!";

                restertTheLevelButton.SetActive(true);
            }
            gameOverPanelObject.SetActive(true);
        }

        public void NextLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }

        public void Restart()
        {
            SceneManager.LoadScene(startLevelId);
        }

        public void RestartThisGame()
        {
            SceneManager.LoadScene(1);
        }
    }
}
