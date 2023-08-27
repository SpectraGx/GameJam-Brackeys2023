using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterAwakens : MonoBehaviour
{

    Animator animator;

    private string currentState;

    //estados de animacion

    
    const string M_Sleep = "BaitBoss";
    const string M_Awakes = "BossAwakens";

     void ChangeAnimationsState(string newState)
    {
        if (currentState == newState) return;

        animator.Play(newState);

        currentState = newState;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("BaitBoss");
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("nave"))
        {
            ChangeAnimationsState(M_Awakes);
        }
    }


    void ShiftScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
