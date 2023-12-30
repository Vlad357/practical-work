using System.Collections;
using UnityEngine;

namespace Platfomer
{
    public class EnemyNPC : Entity
    {
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Attack();
            }
        }
    }
}