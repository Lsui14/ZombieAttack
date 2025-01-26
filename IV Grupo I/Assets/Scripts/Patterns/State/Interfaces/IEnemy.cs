using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{

    public void TakeDamage(int damageAmount);

    public void SetState(IState state);

    public IState GetState();

    public bool GetDeath();   



}
