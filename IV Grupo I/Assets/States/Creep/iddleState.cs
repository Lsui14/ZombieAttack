using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iddleState : StateMachineBehaviour
{
    float timer;
    Transform player;
    float chaseRange = 8;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if(timer > 5)
        {
            animator.SetBool("Walk", true);
        }
        float distance = Vector3.Distance(player.position, animator.transform.position);
        if(distance < chaseRange)
        {
            animator.SetBool("Chase", true);
        }
    }


}
