using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEcena : MonoBehaviour
{

    public void reiniciar(string nombre) 
    {

        SceneManager.LoadScene(nombre);
    
    }


    public void MenuInicial(string nombre) 
    {

        SceneManager.LoadScene(nombre);

    }

    
}
