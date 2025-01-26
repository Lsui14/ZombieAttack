using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Patterns.ObjectPool.Components;
using System;

public class DirtyFlagManager : MonoBehaviour
{

    bool isDirty = false;
    string path = "Assets/Ficheros/DirtyFlag.txt";

    private Player player;

    public int m_hp;
    public int hp
    {
        get => m_hp;
        set
        {
            if (m_hp != value)
            {
                m_hp = value;
                GuardarEstado(path);
            }
        }
    }

    private Arma arma;


    public int m_balas;

    public int balas
    { 
        get => m_balas;
        set 
        { 
          if (m_balas != value)
            {
                m_balas = value;
                GuardarEstado(path);
            }
        } 
    }

    public Vector3 posicion;
    public Quaternion rotation; //Quaternion.Euler




    private void Awake()
    {
        arma = FindObjectOfType<Arma>();
        player = FindObjectOfType<Player>();
    }

    IEnumerator PasaTiempo()
    {
        while (true)
        {
            GuardarEstado(path);
            yield return new WaitForSeconds(15);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Dirty") == 1) LeerEstado(path);
        StartCoroutine(PasaTiempo());
    }

    // Update is called once per frame
    void Update()
    {
        hp = player.HP;
        balas = arma.balas;
        posicion = player.transform.position;
        rotation = player.transform.rotation;
    }



    public void GuardarEstado(string path)
    {   
        StreamWriter writer = new StreamWriter(path, false);
        string estado = JsonUtility.ToJson(this);
        writer.WriteLine(estado);
        writer.Close();

    }

    public void LeerEstado(string path)
    {
        StreamReader reader = new StreamReader(path);
        string estado = reader.ReadLine();
        if (estado != null)
        {
            EstadoAlmacenado estadoGuardado = JsonUtility.FromJson<EstadoAlmacenado>(estado);
            m_hp = estadoGuardado.m_hp;
            m_balas = estadoGuardado.m_balas;
            posicion = estadoGuardado.posicion;
            rotation = estadoGuardado.rotation;

            player.SetHP(hp);
            arma.balas = balas;
            player.transform.position = posicion;
            player.transform.rotation = rotation;
        }

        reader.Close();

    }
}

public class EstadoAlmacenado
{
    public int m_hp;
    public int m_balas;
    public Vector3 posicion;
    public Quaternion rotation; //Quaternion.Euler

}
