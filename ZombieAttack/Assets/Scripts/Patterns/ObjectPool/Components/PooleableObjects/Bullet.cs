using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Patterns.ObjectPool.Interfaces;
using System;


namespace Patterns.ObjectPool.Components
{

    public class Bullet : MonoBehaviour, IPooleableObject
    {
        
        public IObjectPool pool;
        public Transform spawn;
        public int damage;


        private void Update()
        {
            if (transform.position.y < -6 || Physics.CheckSphere(transform.position, 0.25f,
                    LayerMask.GetMask("Suelo"), QueryTriggerInteraction.Ignore))
            {
                
                pool?.Release(this);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            
            if(other.tag == "Enemy")
            {
                other.GetComponent<IEnemy>().TakeDamage(damage);
                pool?.Release(this);
            }
        }


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

        public void Reset()
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.Euler(Vector3.zero);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        public IPooleableObject Clone()
        {
            GameObject newObject = Instantiate(gameObject, spawn.position, spawn.rotation);
            Bullet Bullet = newObject.GetComponent<Bullet>();
            return Bullet;
        }


    }
}
