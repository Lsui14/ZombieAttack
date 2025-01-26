using Patterns.ObjectPool;
using Patterns.ObjectPool.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsPool : MonoBehaviour
{

    //ObjectPool Variables
    public MonoBehaviour Municion;
    public int initialNumber;
    public bool allowed;
    private ObjectPool Pool;
    public int MaxElem;

    void Start()
    {
        Pool = new ObjectPool((IPooleableObject)Municion,initialNumber, allowed, MaxElem);
    }


    public void Create(Vector3 pos, Quaternion rot)
    {
        Ammo power = (Ammo)Pool.Get();

        if (power != null )
        {
            Vector3 vector = new Vector3(pos.x, pos.y + 1f, pos.z);
            power.pool = Pool;
            power.transform.localPosition = vector;
            power.transform.localRotation = rot;
        }
    }

}
