using AI.Controller;
using AI.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

namespace AI.SceneManagement
{
    public class Portal : MonoBehaviour
    {
        enum DestinationIdentifier
        {
            A, B, C, D, E
        }

        [SerializeField] int sceneToLoad = -1;
        [SerializeField] Transform spawnPoint;
        [SerializeField] DestinationIdentifier destination;
        [SerializeField] float fadeOutTime = 1f;
        [SerializeField] float fadeInTime = 2f;
        [SerializeField] float fadeWaitTime = 0.5f;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                StartCoroutine(Transition());
            }
        }
        private IEnumerator Transition()
        {
            if (sceneToLoad < 0)
            {
                Debug.LogError("Scene to load not set");
                yield break;//break the iteration property
            }
            DontDestroyOnLoad(gameObject);
            Fader fader = FindObjectOfType<Fader>();
            SavingWrapper wrapper = FindObjectOfType<SavingWrapper>();
            PlayerCursorController playerController = GameObject.FindWithTag("Player").GetComponent<PlayerCursorController>();
            playerController.enabled = false;

            //DOWN BELOW - fade out -> LoadScene -> Get spawn point and the portal
            //-> wait for some time -> fade in -> Destroy this game object to prevent confusion

            yield return fader.FadeOut(fadeOutTime);
            //Save current level.
            if(gameObject.tag == "LevelToSave")
            {
                wrapper.Save();

            }

            yield return SceneManager.LoadSceneAsync(sceneToLoad);
            PlayerCursorController newPlayerController = GameObject.FindWithTag("Player").GetComponent<PlayerCursorController>();
            newPlayerController.enabled = false;


            //Load current level.
            wrapper.Load();

            Portal otherPortal = GetOtherPortal();
            UpdatePlayer(otherPortal);

            wrapper.Save();

            yield return new WaitForSeconds(fadeWaitTime);
            fader.FadeIn(fadeInTime);


            newPlayerController.enabled = true;
            Destroy(gameObject);
        }

        private void UpdatePlayer(Portal otherPortal)
        {
            GameObject player = GameObject.FindWithTag("Player");

            //WARP is a solution that is used for confusion between NavMesh and player gameObject.transform.position
            //player.GetComponent<NavMeshAgent>().Warp(otherPortal.spawnPoint.position);

            player.GetComponent<NavMeshAgent>().enabled = false;
            player.transform.position = otherPortal.spawnPoint.position;
            player.transform.rotation = otherPortal.spawnPoint.rotation;
            player.GetComponent<NavMeshAgent>().enabled = true;
        }

        private Portal GetOtherPortal()
        {
            foreach (Portal portal in FindObjectsOfType<Portal>())
            {
                if (portal == this) continue;
                if (portal.destination != destination) continue;

                //if portal is not this and destination is the MATCHED one then return that 
                //portal object to spawn in.
                return portal;
            }
            return null;
        }
    }
}