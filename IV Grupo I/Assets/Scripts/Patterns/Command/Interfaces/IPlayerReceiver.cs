using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerReceiver
{
    public void Jump();

    public void MoveRight(float x);

    public void MoveForward(float z);

    public void Sprint();
}
