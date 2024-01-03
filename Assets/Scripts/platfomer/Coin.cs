using UnityEngine;

namespace Platformer
{
    public class Coin : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Player player = collision.gameObject.GetComponentInParent<Player>();
                player.Coin++;
                Destroy(gameObject);
            }
        }
    }
}