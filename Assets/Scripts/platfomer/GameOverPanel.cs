using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer
{
    public class GameOverPanel : MonoBehaviour
    {
        public GameObject gameOverPanelObject;

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

        public void Show()
        {
            gameOverPanelObject.SetActive(true);
        }

        public void Restart()
        {
            SceneManager.LoadScene(startLevelId);
        }
    }
}
