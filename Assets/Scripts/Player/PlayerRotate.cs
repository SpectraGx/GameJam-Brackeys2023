using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [Header("InputSystem ScriptableObject")]
    [SerializeField] InputSystem inputSystem;

    [Header("GameController ScriptableObject")]
    [SerializeField] GameController GM;

    
    [Header("Rotation Data")]
    [SerializeField] float rotateSmooth;
  
    [SerializeField] float minAngle, maxAngle;

    [SerializeField] Quaternion targetRotation;

    [SerializeField] bool rotate;
    void Start()
    {

    }

    void Update()
    {
        if(((!inputSystem.moveL && !inputSystem.moveR) || (!inputSystem.moveL && !inputSystem.moveR)) && !GM.isGamePaused)
        {
            targetRotation = Quaternion.Euler(0, 0, 0);
        }
        else if(inputSystem.moveL && !inputSystem.moveR)
        {
            targetRotation = Quaternion.Euler(0, 0, minAngle);
        }
        else if(!inputSystem.moveL && inputSystem.moveR)
        {
            targetRotation = Quaternion.Euler(0, 0, maxAngle);
        }



        if(transform.rotation != targetRotation)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSmooth * Time.deltaTime);
        }


        
    }



}
