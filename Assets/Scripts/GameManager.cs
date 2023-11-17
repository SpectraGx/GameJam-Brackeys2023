using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField] GameController GM;
    [SerializeField] Transform StartPoint;


    private void Awake()
    {
        GM.GameTime = 1;
        GM.isGamePaused = false;
        GM.respawnPoint = StartPoint;


    }

    void Update()
    {
        GM.activeIFrames -= Time.deltaTime * GM.GameTime;


        
    }
    public void GamePaused()
    {
        
    }


}
