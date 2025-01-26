using Patterns.Command.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadCommand : ICommand
{
    public IArmaReceiver arma;

    public ReloadCommand(IArmaReceiver arma)
    {
        this.arma = arma;
    }

    public void Execute()
    {
        arma.Reload();
    }
}
