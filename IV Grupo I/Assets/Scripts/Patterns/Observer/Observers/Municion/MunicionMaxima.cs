using Patterns.ObjectPool.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunicionMaxima : MonoBehaviour, IObserver
{
    GameObject municion;
    void Start()
    {
        municion = GameObject.FindGameObjectWithTag("Municion");
        ISubject sujeto = municion.GetComponent<ISubject>();
        sujeto.AddObserver(this);
    }

    public void ObserverUpdate()
    {
        GameObject[] armas = GameObject.FindGameObjectsWithTag("Arma");
        foreach (GameObject arma in armas)
        {
            Arma arma1 = arma.GetComponent<Arma>();
            arma1.reserva = arma1.municion * 6;
            arma1.balas = arma1.municion;
            arma1.AmmoInterface();
        }
    }
}
