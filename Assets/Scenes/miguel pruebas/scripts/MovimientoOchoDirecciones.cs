using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoOchoDirecciones : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de movimiento

    void Update()
    {
        // Obtener la entrada del jugador (teclas de flecha)
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        // Calcular el desplazamiento en la dirección
        Vector3 desplazamiento = new Vector3(movimientoHorizontal, movimientoVertical, 0f) * velocidad * Time.deltaTime;

        // Aplicar el desplazamiento al objeto
        transform.Translate(desplazamiento);
    }
}