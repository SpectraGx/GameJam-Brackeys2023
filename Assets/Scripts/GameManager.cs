using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameController GM;

    private void Awake()
    {

        


    }

    void Update()
    {
        GM.activeIFrames -= Time.deltaTime * GM.GameTime;
    }
    public void GamePaused()
    {
        
    }


}
