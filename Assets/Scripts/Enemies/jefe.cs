using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jefe : MonoBehaviour
{    public float velocidadVertical = 2f; // Velocidad de movimiento vertical
    public float velocidadPersecucion = 1f; // Velocidad de persecución del jugador
    public float distanciaDeteccion = 5f; // Distancia a partir de la cual el jefe persigue al jugador

    private Vector3 startPosition;
    private Transform jugador;

    private void Start()
    {
        startPosition = transform.position;
        jugador = GameObject.FindGameObjectWithTag("nave").transform;
    }

    private void Update()
    {
        // Movimiento vertical
        float movimientoVertical = Mathf.Sin(Time.time * velocidadVertical) * 2f; // Rango vertical del movimiento
        Vector3 newPosition = new Vector3(startPosition.x, startPosition.y + movimientoVertical, startPosition.z);

        // Movimiento de persecución hacia el jugador
        if (jugador != null)
        {
            float distanciaAlJugador = Vector3.Distance(transform.position, jugador.position);

            if (distanciaAlJugador <= distanciaDeteccion)
            {
                Vector3 direccionHaciaJugador = (jugador.position - transform.position).normalized;
                newPosition += direccionHaciaJugador * velocidadPersecucion * Time.deltaTime;
            }
        }

        // Aplicar movimiento
        transform.position = newPosition;
    }
}
