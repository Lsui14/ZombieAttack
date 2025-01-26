using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Patterns.ObjectPool.Interfaces
{
    public interface IObjectPool
    {
        public IPooleableObject Get();
        public void Release(IPooleableObject obj);
    }
}
