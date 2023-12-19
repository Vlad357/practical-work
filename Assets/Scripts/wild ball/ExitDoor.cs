using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WildBall
{
    public class ExitDoor : MonoBehaviour
    {
        private void Interact()
        {
            GetComponentInParent<Animator>().SetTrigger("Interact");
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                player.toInteract = Interact;
                GameManager.Instance.textToInteract.SetActive(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                GameManager.Instance.textToInteract.SetActive(true);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                GameManager.Instance.LoadNextLevel();
            }
        }
    }
}

