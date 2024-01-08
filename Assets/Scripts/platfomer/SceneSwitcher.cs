using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer
{
    public class SceneSwitcher : MonoBehaviour
    {
        public int idSceneToLoad;

        public Vector2 positionSceneToLoad;

        private Statistic statistic;

        public void OnSceneLoad(Scene scene, LoadSceneMode mode)
        {
            Player player = FindObjectOfType<Player>();
            player.transform.position = positionSceneToLoad;
            player.Statistic = statistic;
            SceneManager.sceneLoaded -= OnSceneLoad;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                statistic = FindObjectOfType<Player>().Statistic;
                SceneManager.sceneLoaded += OnSceneLoad;
                FindObjectOfType<GameOverPanel>().Show(true);
            }
        }
    }
}