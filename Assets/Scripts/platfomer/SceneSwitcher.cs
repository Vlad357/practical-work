using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer
{
    public class SceneSwitcher : MonoBehaviour
    {
        public int idSceneToLoad;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                SceneManager.LoadScene(idSceneToLoad);
            }
        }
    }
}