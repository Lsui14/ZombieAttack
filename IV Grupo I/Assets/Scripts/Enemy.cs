using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{
    public int HP = 100;
    public Animator animator;
    public int damage;

    public IState GetState()
    {
        throw new NotImplementedException();
    }

    public bool GetDeath()
    {
        return false;
    }

    public void SetState(IState state)
    {
        throw new NotImplementedException();
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if (HP <= 0)
        {
            animator.SetTrigger("Death");
            GetComponent<Collider>().enabled = false;
        }
    }

}
