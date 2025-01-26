using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonLoad : MonoBehaviour
{
    public void Load()
    {
        PlayerPrefs.SetInt("Dirty", 1);
        SceneManager.LoadScene(1);
    }
}
