using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    
    public FloatVariable PlayerHP;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("nave"))
        {
            PlayerHP.floatValue--;
            ScreenShakeV2.Instance.ShakeCamera(3f, 0.1f);
        }
    }
    

 
}
