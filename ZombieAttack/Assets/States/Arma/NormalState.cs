using Patterns.ObjectPool.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalState : StateMachineBehaviour
{
    Arma arma;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        arma = GameObject.FindGameObjectWithTag("Arma").GetComponent<Arma>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(Input.GetKeyUp(KeyCode.R) && arma.recarga) {
            animator.SetBool("Dispara", true);
            
        }
    }
}
