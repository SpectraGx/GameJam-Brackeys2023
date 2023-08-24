using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    private void OnColliderEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Siuuu"))
        {
          
            GameManager.Instance.PerderVida();
        }
    }
   

}
