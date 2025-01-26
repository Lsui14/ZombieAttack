using Patterns.Command.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCommand : ICommand
{
    public IArmaReceiver arma;

    public ShootCommand(IArmaReceiver arma)
    {
        this.arma = arma;
    }

    public void Execute()
    {
        arma.Shoot();
    }
}
