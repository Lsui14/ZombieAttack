using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curacion : MonoBehaviour, IObserver
{

    GameObject Botiquin;
    GameObject player;
    public int Health;

    void Start()
    {
        Botiquin = GameObject.FindGameObjectWithTag("Botiquin");
        player = GameObject.FindGameObjectWithTag("Player");
        ISubject sujeto = Botiquin.GetComponent<ISubject>();
        if (sujeto != null)
        {
            sujeto.AddObserver(this);
        }
    }

    public void ObserverUpdate()
    {
        Player jugador = player.GetComponent<Player>();
        jugador.Health(Health);
        
        
    }
}
