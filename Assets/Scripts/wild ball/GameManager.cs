using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WildBall
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public List<GameObject> obstacles;

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

            FindObstacle();
        }

        private void FindObstacle()
        {
            obstacles.Clear();

            ObstacleAnimationController[] objetcs = FindObjectsOfType<ObstacleAnimationController>();

            foreach (ObstacleAnimationController obj in objetcs)
            {
                obstacles.Add(obj.gameObject);
            }
        }
    }
}
