using Patterns.ObjectPool.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Random = System.Random;

public class Zombie : MonoBehaviour, IEnemy, IPooleableObject
{

    //Stats
    public int HP = 100;
    public int damage;

    //Animation
    public Animator animator;
    IState state;

    //Agent
    NavMeshAgent agent;
    List<Transform> respawns = new List<Transform>();

    //ObjectPool Variables
    public IObjectPool zombies;

    //UI
    public GameObject FloatingText;

    //Random
    Random random;

    ZombieRespawn Zombierespawn;
    public bool death; 

    void Start()
    {
        Zombierespawn = FindObjectOfType<ZombieRespawn>();
        random = new Random();
        GameObject spawns = GameObject.FindGameObjectWithTag("Respawns");
        foreach(Transform t in spawns.transform)
        {
            respawns.Add(t);
        }
        agent = this.animator.GetComponent<NavMeshAgent>();
        SetState(new IddleState(animator, this));
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if (FloatingText)
        {
            ShowFloatingText(damageAmount);
        }
        if (HP <= 0)
        {
            death = true;
            SetState(new DeathState(animator, this, zombies));
            this.GetComponent<Collider>().enabled = false;
            Zombierespawn.muertos++;
            agent.speed = 0;

            int num = random.Next(2);
            if (num == 1)
            {
                GameObject go = GameObject.FindGameObjectWithTag("pool");
                num = random.Next(2);
                if (num == 0)
                {
                    go.GetComponent<PowerUpsPool>().Create(transform.position, transform.rotation);
                }
                else
                {
                    go.GetComponent<BotiquinPool>().Create(transform.position, transform.rotation);
                }
            }
            //zombies?.Release(this);

        }
    }

    public void Chase()
    {
        //state.Exit
    }

    private void ShowFloatingText(int n)
    {
        GameObject texto = Instantiate(FloatingText, transform);
        texto.GetComponent<TextMesh>().text = n.ToString();
    }

    public void Destroy()
    {
        Destroy(gameObject);
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
        transform.localPosition = new Vector3(-94.6f,0,0);
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        this.HP = 0;
        this.animator.SetBool("Alive", false);
        this.agent.speed = 0;
        this.GetComponent<Collider>().enabled = false;

    }

    public IPooleableObject Clone()
    {
        GameObject newObject;
        if (respawns.Count > 0)
        {
            Transform spawn = respawns[UnityEngine.Random.Range(0, respawns.Count)];
            newObject = Instantiate(gameObject, spawn.position, spawn.rotation);
        }
        else
        {
            newObject = Instantiate(gameObject, Vector3.zero, Quaternion.Euler(Vector3.zero));
        }
        Zombie zombie = newObject.GetComponent<Zombie>();
            zombie.animator.SetBool("Alive", true);
            zombie.HP = 100;
            return zombie;
    }

    public void SetState(IState _state)
    {
        if (state != null)
        {
            state.Exit();
        }

        state = _state;
        state.Enter();
    }

    public IState GetState()
    {
        return state;
    }
    public void Update()
    {
        state.Update();
    }

    public bool GetDeath()
    {
        return death;
    }
}
