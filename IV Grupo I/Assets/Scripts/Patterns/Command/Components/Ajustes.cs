using Patterns.ObjectPool.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ajustes : MonoBehaviour, IUIReceiver
{
    public void Start()
    {
        
    }
    public void Execute()
    {
        GameObject menu = GameObject.FindGameObjectWithTag("Menu");
        Cursor.lockState = CursorLockMode.None;
        menu.GetComponent<Canvas>().enabled = true;
        Time.timeScale = 0f;
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Arma arma = GameObject.FindGameObjectWithTag("Arma").GetComponent<Arma>();
        if (player.agotado.isPlaying) player.agotado.Pause();
        if (player.correr.isPlaying) player.correr.Pause();
        if (player.pocaVida.isPlaying) player.pocaVida.Pause();
        if (arma.recargar.isPlaying) arma.recargar.Pause();
    }

}
