using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager Instance;

        private void Start()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);
        }
    }
}