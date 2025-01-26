using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonJuego : MonoBehaviour
{
    public void Menu()
    {
        GameObject menu = GameObject.FindGameObjectWithTag("Menu");
        menu.GetComponent<Canvas>().enabled = true;
        //pausar el juego
    }
}
