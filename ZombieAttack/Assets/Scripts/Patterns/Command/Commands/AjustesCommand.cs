using Patterns.Command.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AjustesCommand : ICommand
{
    IUIReceiver interfaz;

    public AjustesCommand( IUIReceiver interfaz)
    {
        this.interfaz = interfaz;
    }

    public void Execute()
    {
        interfaz.Execute();
    }
}
