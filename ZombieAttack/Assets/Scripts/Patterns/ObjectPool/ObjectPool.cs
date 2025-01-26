using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Patterns.ObjectPool.Interfaces;
using Unity.VisualScripting;

namespace Patterns.ObjectPool
{
    public class ObjectPool : IObjectPool
    {

        private IPooleableObject _objectPrototype;
        private readonly bool _allowAddNew;
        private int initialNumber;
        private List<IPooleableObject> _objects;
        private int MaxElem;
        private int activeObjects;



        public ObjectPool(IPooleableObject objectPrototype, int initialNumberOfElements, bool allowAddNew, int maxElem)
        {
            _objectPrototype = objectPrototype;
            initialNumber = initialNumberOfElements;
            _allowAddNew = allowAddNew;
            MaxElem = maxElem;
            _objects = new List<IPooleableObject>(initialNumberOfElements);
            activeObjects = 0;

            for (int i = 0; i < initialNumberOfElements; i++)
            {
                _objects.Add(CreateObject());
            }
            MaxElem = maxElem;
        }

        public IPooleableObject Get()
        {
            
            for (int i = 0; i < _objects.Count; i++)
            {

                if (!_objects[i].Active)
                {
                    activeObjects++;
                    _objects[i].Active = true;
                    return _objects[i];
                }
            }

            if (_allowAddNew)
            {
                activeObjects++;
                IPooleableObject newObj = CreateObject();
                newObj.Active = true;
                _objects.Add(newObj);

                return newObj;
            }

            return null;
        }

        public void Release(IPooleableObject obj)
        {
            activeObjects--;
            obj.Active = false;
            obj.Reset();
            if (_objects.Count > MaxElem)
            {
                _objects.Remove(obj);
                obj.Destroy();
            }
        }


        private IPooleableObject CreateObject()
        {
            IPooleableObject newObj = _objectPrototype.Clone();
            newObj.Active = false;
            return newObj;
        }

        public int GetActives()
        {
            return activeObjects;
        }
      
        
    }
}
