using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pez_SeguirBehaivor : StateMachineBehaviour
{

    [SerializeField] private float velocidadMovimineto;

    [SerializeField] private float tiempoBase;

    private float tiempoSeguir;

    private Transform jugador;

    private EnemyTracking Anglerfish;



    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tiempoSeguir = tiempoBase;
        jugador = GameObject.FindGameObjectWithTag("Siuuu").GetComponent<Transform>();
        Anglerfish = animator.gameObject.GetComponent<EnemyTracking>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks Siuu

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, jugador.position, velocidadMovimineto * Time.deltaTime);
        Anglerfish.Girar(jugador.position);
        tiempoSeguir -= Time.deltaTime;

        if(tiempoSeguir <= 0)
        {
            animator.SetTrigger("Volver");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}