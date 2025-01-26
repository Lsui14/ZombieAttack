using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkState : IState
{
    Animator animator;
    IEnemy contexto;
    NavMeshAgent agent;
    Transform player;

    public WalkState(Animator animator, IEnemy contexto)
    {
        this.animator = animator;
        this.contexto = contexto;
    }
    public void Enter()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = Random.Range(1, 2.5f);
    }

    public void Exit()
    {
        
    }

    public void Update()
    {
        agent.SetDestination(player.position);
        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance < 1.5)
        {
            
            contexto.SetState(new AttackZombieState(animator, contexto));
        }
    }
}
