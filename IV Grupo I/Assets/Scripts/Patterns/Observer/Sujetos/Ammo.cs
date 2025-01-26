using Patterns.ObjectPool.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo: MonoBehaviour, ISubject, IPooleableObject
{

    List<IObserver> Observers = new List<IObserver>();
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
        Observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        Observers.Remove(observer);
    }

    public void UpdateObservers()
    {
        foreach (IObserver observer in Observers)
        {
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

    public IPooleableObject Clone()
    {
        GameObject go = Instantiate(gameObject);
        Ammo ammo = go.GetComponent<Ammo>();
        foreach (IObserver other in Observers)
        {
            ammo.AddObserver(other);
        }
        return ammo;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

}
