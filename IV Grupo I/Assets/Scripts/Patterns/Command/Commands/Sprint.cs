using Patterns.Command.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprint : ICommand
{
    IPlayerReceiver player;

    public Sprint(IPlayerReceiver player)
    {
        this.player = player;
    }


    public void Execute()
    {
        player.Sprint();
    }

}
