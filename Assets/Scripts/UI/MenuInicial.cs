using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    
    public void Jugar (string nombre)
    {

        SceneManager.LoadScene(nombre);
        Debug.Log("Funciona");

    }

    public void Salir ()
    {
        Debug.Log("Adios tilin...");
        Application.Quit();
    }

    public void Back(){
        Debug.Log("Regrese tilin");
        SceneManager.LoadScene("MainMenu");
    }

}