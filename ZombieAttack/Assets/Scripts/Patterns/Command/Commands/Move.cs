using Patterns.Command.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : ICommand
{

    public IPlayerReceiver player;
    public float x;

    public Move(IPlayerReceiver player, float x)
    {
        this.player = player;
        this.x = x;
    }

    public void Execute()
    {
        player.MoveRight(x);
    }

}
