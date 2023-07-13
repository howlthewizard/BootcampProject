using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionRadius = 0.5f;
    [SerializeField] private LayerMask interactableMask;
    [SerializeField] private InteractionPromptUI interactionPromptUI;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] public int numFound;

    private IInteractable _interactable;

    private void Update()
    {
        numFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionRadius, _colliders, interactableMask);

        if(numFound > 0)
        {
            _interactable = _colliders[0].GetComponent<IInteractable>();

            if(_interactable != null )
            {
                if(!interactionPromptUI.IsDisplayed)
                {
                    interactionPromptUI.SetUp(_interactable.InteractionPrompt);
                }
                if(Input.GetKeyDown(KeyCode.E))
                {
                    _interactable.Interact(this);
                }
            }
        }
        else
        {
            if (_interactable != null) _interactable = null;
            if(interactionPromptUI.IsDisplayed) interactionPromptUI.Close();
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionRadius);
    }

}
