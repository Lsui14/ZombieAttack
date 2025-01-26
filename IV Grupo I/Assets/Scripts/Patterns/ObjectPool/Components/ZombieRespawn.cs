using Patterns.ObjectPool;
using Patterns.ObjectPool.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieRespawn : MonoBehaviour
{
    //ObjectPool Variables
    public MonoBehaviour zombiePrototype;
    public int initialNumber = 5;
    public bool allowed = true;
    public int maxElem;
    private ObjectPool _zombiePool;

    //Respawn Variables
    GameObject Boss;
    Enemy Creep;
    bool ronda = true;
    bool entreronda = false;
    int[] rondas;
    int indice;
    public int muertos;
    List<Transform> respawns = new List<Transform>();
    public float rate = 3f;
    public float rateTime = 0f;
    public float count = 0;
    public TextMeshProUGUI RondaUI;
    public TextMeshProUGUI ZombiesUI;

    void Start()
    {
        _zombiePool = new ObjectPool((IPooleableObject)zombiePrototype, initialNumber, allowed, maxElem);
        GameObject spawns = GameObject.FindGameObjectWithTag("Respawns");
        Boss = GameObject.FindGameObjectWithTag("Boss");
        Creep = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        Boss.SetActive(false);
        indice = 0;
        RondaUI.text = "Ronda " + (indice + 1).ToString();
        rondas = new int[5];
        //rondas[0] = 10;
        //rondas[1] = 15;
        //rondas[2] = 18;
        //rondas[3] = 20;
        //rondas[4] = 30;
        rondas[0] = 5;
        rondas[1] = 10;
        rondas[2] = 15;
        rondas[3] = 20;
        rondas[4] = 25;
        foreach (Transform t in spawns.transform)
        {
            respawns.Add(t);
        }
    }

    private void CreateZombie()
    {

            Zombie zombie = (Zombie)_zombiePool.Get();
            if (zombie)
            {
                zombie.death = false;
                zombie.zombies = _zombiePool;
                Transform spawn = respawns[Random.Range(0, respawns.Count)];
                zombie.transform.localPosition = spawn.position;
                zombie.HP = 100;
                zombie.animator.SetBool("Alive", true);
                zombie.SetState(new IddleState(zombie.animator, zombie));
                zombie.GetComponent<Collider>().enabled = true;
                count++;

            
        }
    }

    void Update()
    {
        ZombiesUI.text = "Zombies: " + _zombiePool.GetActives().ToString();

        if (ronda && Time.time > rateTime && !entreronda && count < rondas[indice])
        {
            CreateZombie();
            rateTime = Time.time + rate;

        }
        if (muertos >= rondas[indice] && indice < rondas.Length - 1)
        {
            count = 0;
            muertos = 0;
            indice++;
            entreronda = true;
            if(indice == rondas.Length - 1)
            {
                Boss.SetActive(true);
            }
            StartCoroutine(CoroutineEntreRonda());
        }

        if (muertos >= rondas[indice] && indice >= rondas.Length - 1)
        {
            SceneManager.LoadScene(3);
        }

        else if (count >= rondas[indice] && indice >= rondas.Length - 1)
        {
            ronda = false;
        }

    }

    private IEnumerator CoroutineEntreRonda()
    {
        yield return new WaitForSeconds(4);
        entreronda = false;
        RondaUI.text = "Ronda " + (indice + 1).ToString();
    }
}
