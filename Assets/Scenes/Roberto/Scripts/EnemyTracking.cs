using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracking : MonoBehaviour
{
    [SerializeField] public Transform jugador;

    [SerializeField] private float distancia;

    public Vector3 puntoinicial;

    private Animator animator;

    private SpriteRenderer spriteRenderer;


    private void Start()
    {
        animator= GetComponent<Animator>();
        puntoinicial = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void Update()
    {
        distancia = Vector2.Distance(transform.position, jugador.position);
        animator.SetFloat("Distancia", distancia);
    }

    public void Girar(Vector3 obejetivo)
    {
    if(transform.position.x<obejetivo.x)
        {
            spriteRenderer.flipX= true;
        }
    else
        {

            spriteRenderer.flipY= false;
        }
    }
}
