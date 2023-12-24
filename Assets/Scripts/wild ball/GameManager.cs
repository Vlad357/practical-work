using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WildBall
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public float timeUntilVictory = 10f;
        public List<GameObject> obstacles;

        public Action LoseAction;

        public GameObject exitPrefab;

        public void LoadNextLevel()
        {
            if(SceneManager.GetActiveScene().buildIndex < 6)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                return;
            }
            SceneManager.LoadScene(1);
        }

        public void LoseEvent()
        {
            StartCoroutine(LoseCorutine());
        }

        private IEnumerator LoseCorutine()
        {
            yield return new WaitForSeconds(1f);
            LoseAction?.Invoke();
        }

        private IEnumerator Countdown()
        {
            if(SceneManager.GetActiveScene().buildIndex != 0 &&
                SceneManager.GetActiveScene().buildIndex != 6)
            {
                yield return new WaitForSeconds(timeUntilVictory);
                DeleteAllObstacle();
                SpawnExit();
            }
        }

        private void SpawnExit()
        {
            Instantiate(exitPrefab);
        }

        private void DeleteAllObstacle()
        {
            foreach (GameObject obstacle in obstacles)
            {
                Destroy(obstacle);
            }
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            StopAllCoroutines();
            Init();
        }

        private void Init()
        {
            StartCoroutine(Countdown());
            FindObstacle();

            LevelEventPanel levelPanel = FindObjectOfType<LevelEventPanel>();
            LoseAction += () => levelPanel.loseEventUI?.Invoke();
        }

        private void Start()
        {
            if (Instance == null)
            {
                Instance = this;
                Init();
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void FindObstacle()
        {
            obstacles.Clear();

            Obstacle[] objetcs = FindObjectsOfType<Obstacle>();

            foreach (Obstacle obj in objetcs)
            {
                obstacles.Add(obj.gameObject);
            }
        }
    }
}
