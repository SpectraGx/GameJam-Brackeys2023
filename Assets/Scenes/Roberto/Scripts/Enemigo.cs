using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public CamaraTemblor camaraTemblor;
    public FloatVariable PlayerHP;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("nave"))
        {
            PlayerHP.floatValue--;
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("nave"))
        {
            camaraTemblor.ShakeCamera();
        }
    }
 
}
