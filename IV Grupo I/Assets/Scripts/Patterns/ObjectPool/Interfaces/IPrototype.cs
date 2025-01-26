using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Patterns.ObjectPool.Interfaces
{
    public interface IPrototype
    {
        public IPooleableObject Clone();
    }
}
