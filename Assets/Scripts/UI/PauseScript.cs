using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    
    [SerializeField] GameController GM;
    [SerializeField] GameObject PausePanel;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GM.isGamePaused)
            {
                GM.GameTime = 1;
                PausePanel.SetActive(false);
                GM.isGamePaused = false;
            }
            else
            {
                GM.GameTime = 0;
                PausePanel.SetActive(true);
                GM.isGamePaused = true;
            }
        }
    }
    
}
