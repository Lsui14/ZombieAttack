using Patterns.ObjectPool.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : IState
{
    Animator animator;
    IEnemy contexto;
    IObjectPool pool;


    public DeathState(Animator animator, IEnemy contexto, IObjectPool Pool)
    {
        this.contexto = contexto;
        this.animator = animator;
        this.pool = Pool;
    }
    public void Enter()
    {
        animator.SetTrigger("Death");
        animator.SetBool("Alive", false);
        MonoBehaviour mono = contexto as MonoBehaviour;
        mono.StartCoroutine(CoroutineDeath());

    }

    public void Exit()
    {
        
    }

    public void Update()
    {
       
    }

    private IEnumerator CoroutineDeath()
    {
        yield return new WaitForSeconds(5);
        IPooleableObject contextoPool = contexto as IPooleableObject;
        pool?.Release(contextoPool);
    }
}
