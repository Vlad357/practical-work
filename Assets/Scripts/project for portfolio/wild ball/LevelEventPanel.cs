using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace WildBall
{
    public class LevelEventPanel : MonoBehaviour
    {
        public UnityEvent loseEventUI;

        public void LoadLevel(int id)
        {
            SceneManager.LoadScene(id);
        }
        public void ReloadScene()
        {
            GameManager.Instance.StopAllCoroutines();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}