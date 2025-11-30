using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class Matt_changed : MonoBehaviour
{
    [Header("Navigation")]
    public Transform destination;
    public UnityEvent onArrive;
    public UnityEvent onFirstMove;
    public Transform[] altDestinations;

    [Header("Graphics")]
    public Animator avatarAnimator;
    public string speedString = "speed";

    [Header("System Stuff")]
    public NavMeshAgent myNma;
    private bool hasStartedMoving = false;
    private bool hasArrived = false;

    void Start()
    {
        if (myNma == null)
            myNma = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (destination != null && destination.gameObject.activeSelf)
        {
            myNma.SetDestination(destination.position);
        }

        if (!hasStartedMoving && myNma.velocity.sqrMagnitude > 0.01f)
        {
            hasStartedMoving = true;
            onFirstMove.Invoke();
        }

        // Determine whether it has truly arrived
        if (hasStartedMoving && !hasArrived && !myNma.pathPending && myNma.remainingDistance <= myNma.stoppingDistance)
        {
            if (!myNma.hasPath || myNma.velocity.sqrMagnitude == 0f)
            {
                hasArrived = true;
                onArrive.Invoke();
            }
        }

        HandleAvatar();
    }

    public void SetDestination(Transform newDest)
    {
        destination = newDest;
        hasStartedMoving = false;
        hasArrived = false;
    }

    public void SetDestination(int i)
    {
        if (altDestinations.Length > 0)
        {
            int randomIndex = Random.Range(0, altDestinations.Length);
            destination = altDestinations[randomIndex];
            hasStartedMoving = false;
            hasArrived = false;
        }
    }

    public void HandleAvatar()
    {
        if (myNma != null && avatarAnimator != null)
        {
            avatarAnimator.SetFloat(speedString, myNma.velocity.magnitude);
        }
    }
}
