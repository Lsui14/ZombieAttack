using Patterns.ObjectPool.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botiquin : MonoBehaviour, ISubject, IPooleableObject
{
    List<IObserver> observers = new List<IObserver>();
    public IObjectPool pool;

    public bool Active
    {
        get
        {
            return gameObject.activeSelf;
        }

        set
        {
            gameObject.SetActive(value);
        }
    }

    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void UpdateObservers()
    {
        Debug.Log("hola");
        Debug.Log(observers.Count);
        foreach (var observer in observers) {
            observer.ObserverUpdate();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;

        UpdateObservers();
        pool?.Release(this);
    }

    public void Reset()
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public IPooleableObject Clone()
    {
        GameObject go = Instantiate(gameObject);
        Botiquin botiquin = go.GetComponent<Botiquin>();
        foreach (IObserver other in observers)
        {
            botiquin.AddObserver(other);
        }
        return botiquin;
    }
}
