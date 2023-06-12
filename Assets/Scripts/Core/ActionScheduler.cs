using UnityEngine;

namespace AI.Core
{
    public class ActionScheduler : MonoBehaviour
    {
        IAction currentAction;

        //HERE DOWN BELOW CANCEL THE PREVIOUS ACTION
        public void StartAction(IAction action)
        {
            if (currentAction == action) return;
            if (currentAction != null)
            {
                currentAction.Cancel();
                //Points directly to Cancel method in that specific /ACTION\ parameter.
                //Through the IAction interface.
            }
            currentAction = action;
        }
        public void CancelCurrentAction() //Cancel action when any GameObject is death.
        {
            StartAction(null);
        }
    }
}