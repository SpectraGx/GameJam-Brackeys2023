using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrulla : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private Transform[] puntosMovimientos;

    [SerializeField] private float distanciaMinima;

    private int siguientePaso = 0;


    private void Start()
    {

        Girar();

    }


    private void Update()
    {
        transform.localPosition = Vector3.MoveTowards(transform.position, puntosMovimientos[siguientePaso].position, velocidadMovimiento * Time.deltaTime);
        Girar();

        if(Vector2.Distance(transform.localPosition, puntosMovimientos[siguientePaso].position) < distanciaMinima)
        {

            siguientePaso += 1;
            if (siguientePaso >= puntosMovimientos.Length)
            {
                siguientePaso = 0;
            }
        }
    }

    private void Girar() 
    {

        if((puntosMovimientos[siguientePaso].position.x > 0 && transform.localScale.x != 1) || (puntosMovimientos[siguientePaso].position.x < 0 && transform.localScale.x != -1))
        {
            Vector3 transformScale = transform.localScale;
            transformScale.x *= -1;
            transform.localScale = transformScale;
        }

    }
}
