using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicFollowBehaviour : StateMachineBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timeBase;
    private float timeFollow;
    private Transform player;
    private MimicMachineState mimic;
    [SerializeField] private GameController GM;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeFollow = timeBase;
        player = GameObject.FindGameObjectWithTag("nave").GetComponent<Transform>();
        mimic = animator.gameObject.GetComponent<MimicMachineState>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        mimic.Collider2();
        animator.transform.position = Vector2.MoveTowards(animator.transform.position,player.position,speed*Time.deltaTime*GM.GameTime);
        mimic.Girar(player.position);
        timeFollow -= Time.deltaTime*GM.GameTime;
        if (timeFollow<=0){
            animator.SetTrigger("Volver");
        }
    }

}
