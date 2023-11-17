using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField] GameController GM;
    [SerializeField] Transform StartPoint;
    [SerializeField] GameObject PausePanel;

    private void Awake()
    {
        GM.GameTime = 1;
        GM.isGamePaused = false;
        GM.respawnPoint = StartPoint;


    }

    void Update()
    {
        GM.activeIFrames -= Time.deltaTime * GM.GameTime;


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
    public void GamePaused()
    {
        
    }


}
