using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    [SerializeField] private GameController gm;
    private MovimientoOchoDirecciones pj;
    private void OnTriggerEnter2D(Collider2D other) {
        gm.KeysObtained++;
        Destroy(gameObject);
    }
}
