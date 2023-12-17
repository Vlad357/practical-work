using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace WildBall
{
    public class LevelEventPanel : MonoBehaviour
    {
        public UnityEvent losePanel;

        public void LoadLevel(int id)
        {
            SceneManager.LoadScene(id);

        }


        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void Start()
        {
            if(SceneManager.GetActiveScene().buildIndex != 0)
            {
                GameManager.Instance.LoseAction += () =>
                {
                    losePanel?.Invoke();
                };
            }
        }
    }
}