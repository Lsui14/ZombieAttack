using Patterns.ObjectPool.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonMenu : MonoBehaviour
{
    public void continuar()
    {
        GameObject menu = GameObject.FindGameObjectWithTag("Menu");
        menu.GetComponent<Canvas>().enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;

        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Arma arma = GameObject.FindGameObjectWithTag("Arma").GetComponent<Arma>();
        player.agotado.UnPause();
        player.correr.UnPause();
         player.pocaVida.UnPause();
        arma.recargar.UnPause();
        //volver al juego
    }

    public void parar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
