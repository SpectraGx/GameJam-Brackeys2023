using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracking : MonoBehaviour
{
    [SerializeField] public Transform jugador;

    [SerializeField] private float distancia;

    public Vector3 puntoinicial;

    private Animator animator;


    private void Start()
    {
        animator= GetComponent<Animator>();
        puntoinicial = transform.position;

    }

    private void Update()
    {
        distancia = Vector2.Distance(puntoinicial, jugador.position);
        animator.SetFloat("Distancia", distancia);
    }

    public void Girar(Vector3 objective)
    {
    if((objective.x > 0 && transform.localScale.x != 1) || (objective.x < 0 && transform.localScale.x != -1))
        {
            Vector3 transformScale = transform.localScale;
            transformScale.x *= -1;
            transform.localScale = transformScale;
        }
    }
}
