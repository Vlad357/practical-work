using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platfomer 
{
    public class LosePanel : MonoBehaviour
    {
        public GameObject losePanelObject;

        public void Show()
        {
            losePanelObject.SetActive(true);
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
