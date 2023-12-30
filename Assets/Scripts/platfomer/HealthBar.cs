using UnityEngine;
using UnityEngine.UI;

namespace Platformer
{
    public class HealthBar : MonoBehaviour
    {
        public Image hpBar;
        public void SetHealth(float currentHP, float maxHP)
        {
            hpBar.fillAmount = currentHP / maxHP;
        }
    }
}
