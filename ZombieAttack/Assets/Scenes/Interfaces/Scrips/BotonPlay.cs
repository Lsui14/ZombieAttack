using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonPlay : MonoBehaviour
{
    public void Play()
    {
        PlayerPrefs.SetInt("Dirty", 0);
        SceneManager.LoadScene(1);
    }

    public void Credits()
    {
        SceneManager.LoadScene(4);
    }

    public void Help()
    {
        SceneManager.LoadScene(5);
    }
}
