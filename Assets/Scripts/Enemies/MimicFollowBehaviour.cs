using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicFollowBehaviour : StateMachineBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timeBase;
    private float timeFollow;
    private Transform player;
    private IAmimic mimic;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeFollow = timeBase;
        player = GameObject.FindGameObjectWithTag("nave").GetComponent<Transform>();
        mimic = animator.gameObject.GetComponent<IAmimic>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position,player.position,speed*Time.deltaTime);
        mimic.Girar(player.position);
        timeFollow -= Time.deltaTime;
        if (timeFollow<=0){
            animator.SetTrigger("Volver");
        }
    }

}
