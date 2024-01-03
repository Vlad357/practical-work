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
            // TODO: implement save game
            SceneManager.LoadScene("Main menu");
        }
    }
}