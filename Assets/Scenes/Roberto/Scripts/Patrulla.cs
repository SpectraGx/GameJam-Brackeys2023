using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrulla : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private Transform[] puntosMovimientos;

    [SerializeField] private float distanciaMinima;

    private int siguientePaso = 0;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
       
        spriteRenderer = GetComponent<SpriteRenderer>();
        Girar();

    }


    private void Update()
    {
        transform.position= Vector3.MoveTowards(transform.position, puntosMovimientos[siguientePaso].position, velocidadMovimiento * Time.deltaTime);


        if(Vector2.Distance(transform.position, puntosMovimientos[siguientePaso].position) < distanciaMinima)
        {

            siguientePaso += 1;
            if (siguientePaso >= puntosMovimientos.Length)
            {
                siguientePaso = 0;
            }
            Girar();
        }
    }

    private void Girar() 
    {
        if (transform.position.x < puntosMovimientos[siguientePaso].position.x)
        {
         spriteRenderer.flipX = true;
        }
        else 
        { 
         spriteRenderer.flipY = false;
        }


    }
}
