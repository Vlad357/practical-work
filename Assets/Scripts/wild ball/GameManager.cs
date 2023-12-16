using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WildBall
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public void LoadGameScene(int index)
        {
            SceneManager.LoadScene(index);
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void Start()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if(Instance == this)
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);
        }
    }
}
