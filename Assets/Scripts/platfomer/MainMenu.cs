using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer
{
    public class MainMenu : MonoBehaviour
    {
        public string startGameSceneName = "level 1";
        public void StartGame()
        {
            SceneManager.LoadScene(startGameSceneName);
        }

        public void LoadLevel(int id)
        {
            SceneManager.LoadScene(id);
        }

        public void Out()
        {
            Application.Quit();
        }
    }
}