using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class IddleState : IState
{
    Animator animator;
    IEnemy contexto;
    Random rand;

    public IddleState(Animator animator, IEnemy contexto)
    {
        this.contexto = contexto;
        this.animator = animator;
    }

    public void Start()
    {
        
    }

    public void Enter()
    {
        rand = new Random();
        MonoBehaviour mono = contexto as MonoBehaviour;
        mono.StartCoroutine(CorutinaIdle());
    }

    public void Exit()
    {

    }

    public void Update()
    {

    }

    public IEnumerator CorutinaIdle()
    {
        
        yield return new WaitForSeconds(3);
        float n = (float)rand.NextDouble();
        
        if (contexto.GetDeath() == false)
        {
            if (n < 0.5f)
            {
                animator.SetInteger("Walk", 0);
                contexto.SetState(new WalkState(animator, contexto));
            }

            else
            {
                animator.SetInteger("Walk", 1);
                contexto.SetState(new RunState(animator, contexto));
            }
        }
        
        
    }



}
