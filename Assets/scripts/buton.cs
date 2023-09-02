using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buton : MonoBehaviour
{
    public Canvas canvas;

    public void Exit()
    {
        Application.Quit();
    }
    public void Startli()   //start ve try again butonlarý için
    {
        canvas.enabled = false;
    }
}
