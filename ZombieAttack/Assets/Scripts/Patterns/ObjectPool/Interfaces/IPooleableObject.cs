using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Patterns.ObjectPool.Interfaces
{
    public interface IPooleableObject: IPrototype
    {
        public bool Active
        {
            get;
            set;
        }

        public void Reset();

        public void Destroy();
    }
}
