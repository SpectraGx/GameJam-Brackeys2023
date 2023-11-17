using UnityEngine;

public class Pez_SeguirBehaivor : StateMachineBehaviour
{

    [SerializeField] GameController GM;
    [SerializeField] private float velocidadMovimineto;




    private Transform jugador;


    private Patrulla Fish;
    private EnemyTracking FishTrack;



    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        jugador = GameObject.FindGameObjectWithTag("nave").GetComponent<Transform>();
        FishTrack = animator.gameObject.GetComponent<EnemyTracking>();
        Fish = animator.gameObject.GetComponent<Patrulla>();
        Fish.OnChase = true;
        //animator.transform.position = Anglerfish.transform.position;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks Siuu

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, jugador.position, velocidadMovimineto * Time.deltaTime * GM.GameTime);
        FishTrack.Girar(jugador.position);
        

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
