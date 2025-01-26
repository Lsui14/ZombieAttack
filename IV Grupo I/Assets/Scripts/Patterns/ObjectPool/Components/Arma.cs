using Patterns.Command.Interfaces;
using Patterns.ObjectPool.Interfaces;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

namespace Patterns.ObjectPool.Components
{
    public class Arma : MonoBehaviour, IArmaReceiver
    {
        //ObjectPool Variables
        public MonoBehaviour bulletPrototype;
        public int initialNumberOfBullets = 30;
        public bool allowAddNewBullets;
        private ObjectPool _bulletsPool;
        public int MaxElem;

        //Charger Variables
        public int municion = 30;
        public int balas = 30;
        public int reserva = 180;
        public bool recarga = false;

        //Shoot Variables
        public Transform spawn;
        public float force = 1500;
        public float rate = 0.5f;
        private float rateTime = 0;

        //UI
        public TextMeshProUGUI interfaz;

        //Audio
        public AudioSource disparo; 
        public AudioSource recargar; 
        
        private void Start()
        {
            Assert.IsTrue(bulletPrototype is IPooleableObject);
            _bulletsPool = new ObjectPool((IPooleableObject)bulletPrototype, initialNumberOfBullets, allowAddNewBullets, MaxElem);
            AmmoInterface();
        }


        private Bullet CreateBullet()
        {
            
            Bullet bullet = (Bullet)_bulletsPool.Get();
            
            if (bullet)
            {
                
                bullet.pool = _bulletsPool;
                bullet.transform.localPosition = spawn.position;
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                Quaternion vector = new Quaternion(player.transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z, player.transform.rotation.w);
                
                bullet.transform.localRotation = vector;
                bullet.GetComponent<Rigidbody>().AddForce(spawn.forward * force);
                rateTime = Time.time + rate;
                
            }

            return bullet;
        }


        public void Shoot()
        {
            if (Time.time > rateTime && balas > 0 && !recarga)
            {

                Bullet bullet = CreateBullet();
                balas--;
                AmmoInterface();
                rateTime = Time.time + rate;
                if (!disparo.isPlaying) { disparo.Play(); }
            }
        }

        public void Reload()
        {
            if (reserva > 0 && balas != municion && !recarga)
            {
                recarga = true;
                int aux = Mathf.Min(balas + reserva, municion);
                int aux2 = municion - balas;
                balas = aux;
                reserva = Mathf.Max(reserva - aux2, 0);
                AmmoInterface();
                if (!recargar.isPlaying) { recargar.Play(); }
                disparo.Stop();
            }
        }

        public void AmmoInterface()
        {
            interfaz.text = balas + "/" + reserva;
        }
    }
}
