using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Patterns.Command.Interfaces;


namespace Patterns.Command.Commands
{
    public class MoveForward : ICommand
    {

        public IPlayerReceiver player;
        public float z;

        public MoveForward(IPlayerReceiver player, float z)
        {
            this.player = player;
            this.z = z;
        }

        public void Execute()
        {
            player.MoveForward(z);
        }

    }
}
