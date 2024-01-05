using UnityEngine;

namespace Platformer
{
    public struct Statistic
    {
        public float takenDamage;
        public float damageDone;
        public int coins;

        public Statistic(float takenDamage, float damageDone, int coins)
        {
            this.takenDamage = takenDamage;
            this.damageDone = damageDone;
            this.coins = coins;
        }
    }
}
