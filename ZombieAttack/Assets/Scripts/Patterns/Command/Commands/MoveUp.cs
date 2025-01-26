using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Patterns.Command.Interfaces;


namespace Patterns.Command.Commands
{
    public class MoveUp : ICommand
    {

        public IPlayerReceiver player;

        public MoveUp(IPlayerReceiver player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.Jump();
        }

    }
}
