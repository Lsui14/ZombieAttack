using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAmmo : MonoBehaviour, IObserver
{

    GameObject municion;
    private AudioSource audio;

    public void ObserverUpdate()
    {
        audio.Play();
    }

    void Start()
    {
        municion = GameObject.FindGameObjectWithTag("Municion");
        audio = GetComponent<AudioSource>();
        ISubject sujeto = municion.GetComponent<ISubject>();
        if (sujeto != null)
        {
            sujeto.AddObserver(this);
        }
    }

}
