using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer
{
    public class PauseMenu : MonoBehaviour
    {
        public void PauseGame(float timeScale)
        {
            Time.timeScale = timeScale;
        }

        public void ExitToMainMenu()
        {
            SceneManager.LoadScene("Main menu");
        }
    }
}