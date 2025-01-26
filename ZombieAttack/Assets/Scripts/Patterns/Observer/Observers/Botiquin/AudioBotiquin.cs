using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBotiquin : MonoBehaviour, IObserver
{
    GameObject botiquin;
    private AudioSource audio;
    void Start()
    {
        botiquin = GameObject.FindGameObjectWithTag("Botiquin");
        audio = GetComponent<AudioSource>();
        ISubject sujeto = botiquin.GetComponent<ISubject>();
        if (sujeto != null)
        {
            sujeto.AddObserver(this);
        }
    }

    public void ObserverUpdate()
    {
        audio.Play();
    }
}
