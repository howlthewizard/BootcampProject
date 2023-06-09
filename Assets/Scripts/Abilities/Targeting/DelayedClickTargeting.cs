using UnityEngine;
using AI.Controller;
using System.Collections;
using System;
using System.Collections.Generic;

namespace AI.Abilities.Targeting
{
    [CreateAssetMenu(fileName = "Delayed Click Targeting", menuName = "Abilities/Targeting/Delayed Click", order = 0)]
    public class DelayedClickTargeting : TargetingStrategy
    {
        [SerializeField] Texture2D cursorTexture;
        [SerializeField] Vector2 cursorHotspot;
        [SerializeField] LayerMask layerMask;
        [SerializeField] float areaAffectRadius;
        [SerializeField] Transform targetingPrefab;

        Transform targetingPrefabInstance = null;

        public override void StartTargeting(AbilityData data, Action finished)
        {
            PlayerCursorController playerController = data.GetUser().GetComponent<PlayerCursorController>();
            playerController.StartCoroutine(Targeting(data, playerController, finished));
        }

        private IEnumerator Targeting(AbilityData data, PlayerCursorController playerController, Action finished)
        {
            playerController.enabled = false;
            if(targetingPrefabInstance == null)
            {
                targetingPrefabInstance = Instantiate(targetingPrefab);
            }
            else
            {
                targetingPrefabInstance.gameObject.SetActive(true);
            }

            targetingPrefabInstance.localScale = new Vector3(areaAffectRadius * 2, 1, areaAffectRadius * 2);
            while (true)
            {
                Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
                RaycastHit raycastHit;

                if (Physics.Raycast(PlayerCursorController.GetMouseRay(),out raycastHit, 1000, layerMask))
                {
                    targetingPrefabInstance.position = raycastHit.point;

                    if (Input.GetMouseButtonDown(0))
                    {
                        /*while (Input.GetMouseButtonDown(0))
                        {
                            yield return null;
                        }*/
                        yield return new WaitWhile(() => Input.GetMouseButton(0));
                        playerController.enabled = true;
                        targetingPrefabInstance.gameObject.SetActive(false);
                        data.SetTargetedPoint(raycastHit.point);
                        data.SetTargets(GetGameObjectsInRadius(raycastHit.point));
                        finished();
                        yield break;
                    }
                }
                
                yield return null;
            }
        }

        private IEnumerable<GameObject> GetGameObjectsInRadius(Vector3 point)
        {
        
            RaycastHit[] hits = Physics.SphereCastAll(point, areaAffectRadius, Vector3.up, 0);
            foreach(var hit in hits)
            {
                yield return hit.collider.gameObject;
            }
           
        }
    }
}
