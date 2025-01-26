using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZombieState : IState
{
    Animator animator;
    IEnemy contexto;
    Transform player;
    Player jugador;
    float rate = 4;
    float rateTime = 0;
    bool atacar = true;

    public void Start()
    {
        
    }
    public AttackZombieState(Animator animator, IEnemy contexto)
    {
        this.animator = animator;
        this.contexto = contexto;
    }

    public void Enter()
    {
        animator.SetBool("Attack", true);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        jugador = player.GetComponent<Player>();
        
    }

    public void Exit()
    {
        
    }

    void IState.Update()
    {
        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (animator.GetInteger("Walk") == 0 && distance >= 1.5)
        {
            animator.SetBool("Attack", false);
            contexto.SetState(new WalkState(animator, contexto));
        }
        else if(animator.GetInteger("Walk") == 1 && distance >= 2.5)
        {
            animator.SetBool("Attack", false);
            contexto.SetState(new RunState(animator, contexto));
        }
        if (atacar)
        {
            animator.SetBool("Attack", true);
            jugador.TakeDamage(animator.GetComponent<Zombie>().damage);
            atacar = false;
            MonoBehaviour mono = contexto as MonoBehaviour;
            mono.StartCoroutine(CoruoutineAttack());
        }





      
    }

    private IEnumerator CoruoutineAttack()
    {
        yield return new WaitForSeconds(1.0575f);
        atacar = true;
    }

}
