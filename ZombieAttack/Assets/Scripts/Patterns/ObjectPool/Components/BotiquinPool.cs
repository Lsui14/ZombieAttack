using Patterns.ObjectPool;
using Patterns.ObjectPool.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotiquinPool : MonoBehaviour
{

    //ObjectPool Variables
    public MonoBehaviour Boti;
    public int initialNumber;
    public bool allowed;
    public int maxNumber;
    private ObjectPool Pool;


    void Start()
    {
        Pool = new ObjectPool((IPooleableObject)Boti, initialNumber, allowed, maxNumber);
    }


    public void Create(Vector3 pos, Quaternion rot)
    {
        Botiquin power = (Botiquin)Pool.Get();

        if (power != null)
        {
            Vector3 vector = new Vector3(pos.x, pos.y + 1f, pos.z);
            power.pool = Pool;
            power.transform.localPosition = vector;
            power.transform.localRotation = rot;
        }
    }
}
