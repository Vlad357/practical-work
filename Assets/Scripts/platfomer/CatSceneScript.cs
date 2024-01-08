using System.Collections;
using TMPro;
using UnityEngine;

namespace Platformer
{
    public class CatSceneScript : MonoBehaviour
    {
        public TextMeshProUGUI textToCatScene;

        public string[] textToDisplay;

        private void Start()
        {
            StartCoroutine(CatScene());
        }

        private IEnumerator CatScene()
        {
            yield return new WaitForSeconds(2.5f);
            textToCatScene.text = textToDisplay[0];
            yield return new WaitForSeconds(2.5f);
            textToCatScene.text = textToDisplay[1];
            yield return new WaitForSeconds(2.5f);
            textToCatScene.text = textToDisplay[2];
        }
    }
}