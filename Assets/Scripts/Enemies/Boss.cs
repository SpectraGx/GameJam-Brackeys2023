using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Boss : MonoBehaviour
{
    public Transform pj; // Referencia al transform del jugador
    public float moveSpeed = 5f; // Velocidad de movimiento del enemigo

    public FloatVariable PlayerHP;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("nave"))
        {
            PlayerHP.floatValue=0;
        }
    }

    private void Update()
    {
        // Movimiento horizontal hacia adelante
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        // Seguimiento en el eje Y
        if (pj.position.y > transform.position.y)
        {
            // Se mueve el enemigo hacia arriba
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
        else if (pj.position.y < transform.position.y)
        {
            // Se mueve el enemigo hacia abajo
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
    }
}
