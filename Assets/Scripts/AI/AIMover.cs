using UnityEngine;
using UnityEngine.AI;
using AI.Core;
using Attributes;

namespace AI.Movement

{
    //You could inhterit more than 1 intrfc, whereas just 1 class
    public class AIMover : MonoBehaviour, IAction
    {
        [SerializeField] Transform target;
        [SerializeField] float maxSpeed = 1.5f;
        [SerializeField] float maxPathLength = 40f;


        NavMeshAgent navMeshAgent;
        Health health;

        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            health = GetComponent<Health>();
        }
        void Update()
        {
            navMeshAgent.enabled = !health.IsDead();//If player is dead then disable NMAgent.

           // UpdateAnimator();
        }
        public void StartMoveAction(Vector3 destination, float speedFraction)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            MoveTo(destination, speedFraction);
        }

       /* public void UpdateAnimator()
        {
            Vector3 velocity = navMeshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }*/
        public void Cancel()//MUST BE THE SAME METHOD NAME LIKE IN INTERFACE
        {
            navMeshAgent.isStopped = true;
        }
        public bool CanMoveTo(Vector3 destination)
        {
            NavMeshPath navMeshPath = new NavMeshPath();
            bool hasPath = NavMesh.CalculatePath(transform.position, destination, NavMesh.AllAreas, navMeshPath);
            if (!hasPath) return false;
            if (navMeshPath.status != NavMeshPathStatus.PathComplete) return false;//In order to prevent path calculation to the ROOFTOPS.
            if (GetPathLength(navMeshPath) > maxPathLength) return false;//When the destination is way far off from our position.

            return true; // When every other conditions are not succeeded then return true;
        }
        private float GetPathLength(NavMeshPath navMeshPath)
        {//Summation of these path corners in the navMeshPath.
            float total = 0;
            if (navMeshPath.corners.Length < 2) return total; //When there is just 1 line with 2 corners return 0;.
            for (int i = 0; i < navMeshPath.corners.Length - 1; i++)
            {
                total += Vector3.Distance(navMeshPath.corners[i], navMeshPath.corners[i + 1]);//Sum of our path lines.
            }
            return total;
        }

        public void MoveTo(Vector3 destination, float speedFraction)
        {
            navMeshAgent.destination = destination;
            navMeshAgent.speed = maxSpeed * Mathf.Clamp01(speedFraction);
            navMeshAgent.isStopped = false;
        }

    }

}