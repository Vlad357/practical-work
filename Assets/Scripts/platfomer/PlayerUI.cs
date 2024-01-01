using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer
{
    public class PlayerUI : MonoBehaviour
    {
        public Image hpBar;
        public TextMeshProUGUI coinCounter;
        public void SetHealth(float currentHP, float maxHP)
        {
            hpBar.fillAmount = currentHP / maxHP;
        }

        public void SetCoins(int coins)
        {
            coinCounter.text = coins.ToString();
        }
    }
}
