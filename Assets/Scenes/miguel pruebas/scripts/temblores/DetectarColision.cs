using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarColision : MonoBehaviour
{
public CamaraShake camaraShake;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ObjetoSacudible"))
        {
            camaraShake.ShakeCamera();
        }
    }
}
