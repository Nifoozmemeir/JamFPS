using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWalkState : State
{
    [SerializeField] private State rangeAttackState;

    private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform player;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float detectionRadius;

    private Animator animator;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    public override State RunCurrentState()
    {
        Collider[] players = Physics.OverlapSphere(transform.position, detectionRadius, playerLayer);

        if (players.Length > 0)
        {
            navMeshAgent.isStopped = true;
            animator.SetBool("IsShooting", true);
            return rangeAttackState;
        }
        else
        {
            navMeshAgent.isStopped = false;
            animator.SetBool("IsShooting", false);
            navMeshAgent.SetDestination(player.position);
            return this;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}