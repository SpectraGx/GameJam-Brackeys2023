using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}

    public VidaPlayer vida;

    private int vidas = 3;


    private void Awake()
    {
        if (Instance = null)
        {
            Instance = this;

        }
        else 
        {
            Debug.Log("Tilin es mi dios y yo soy su pastor");

        }


    }


    public void PerderVida()
    {
       vidas -= 1;
       vida.DesactivarVida(vidas);

    }
}
