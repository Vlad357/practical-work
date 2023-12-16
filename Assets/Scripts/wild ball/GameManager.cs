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
            if(SceneManager.GetActiveScene().buildIndex < 5)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                return;
            }
            SceneManager.LoadScene(1);
        }

        public void LoseEvent()
        {
            LoseAction?.Invoke();
        }

        private IEnumerator Countdown()
        {
            if(SceneManager.GetActiveScene().buildIndex != 0)
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
            StartCoroutine(Countdown());
            FindObstacle();
        }

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

            StartCoroutine(Countdown());
            FindObstacle();

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
