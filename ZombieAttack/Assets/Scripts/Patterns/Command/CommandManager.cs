using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Patterns.Command.Interfaces;


namespace Patterns.Command
{
    public class CommandManager
    {
        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
        }
    }
}
