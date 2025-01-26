using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    Transform player;
    Player jugador;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        jugador = player.GetComponent<Player>();
        jugador.TakeDamage(animator.GetComponent<Enemy>().damage);
        //jugador.HP -= 10;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.transform.LookAt(player);
        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance > 3.5f)
        {
            animator.SetBool("Attack", false);
        }
    }


}
