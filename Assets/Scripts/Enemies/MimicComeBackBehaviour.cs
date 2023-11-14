using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicComeBackBehaviour : StateMachineBehaviour
{
    [SerializeField] private float speed;
    private Vector3 startPoint;
    private IAmimic mimic;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        mimic = animator.gameObject.GetComponent<IAmimic>();
        startPoint = mimic.startingPoint;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, startPoint, speed*Time.deltaTime);
        mimic.Girar(startPoint);
        if (animator.transform.position == startPoint){
            animator.SetTrigger("Regreso");
        }
    }
}