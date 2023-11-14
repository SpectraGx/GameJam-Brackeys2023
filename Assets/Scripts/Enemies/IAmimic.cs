using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAmimic : MonoBehaviour
{
    [SerializeField] public Transform player;
    [SerializeField] private float dist;

    public Vector3 startingPoint;
    private Animator animator;
    private SpriteRenderer spriteRenderer;


    private void Start(){
        animator = GetComponent<Animator>();
        startingPoint = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        dist = Vector2.Distance(transform.position,player.position);
        animator.SetFloat("Distancia",dist);
    }

    public void Girar(Vector3 objetivo) {
        if (transform.position.x < objetivo.x){
            spriteRenderer.flipX = true;
        }
        else{
            spriteRenderer.flipX = false;
        }
    }
}
