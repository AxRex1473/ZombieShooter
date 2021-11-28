using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void LoadSceneMode()
    {
        SceneManager.LoadScene("Juego");
    }

    public void LoadSceneMode1()
    {
        SceneManager.LoadScene("Controls");
    }

    public void LoadSceneMode2()
    {
        SceneManager.LoadScene("Menu");
    }

}