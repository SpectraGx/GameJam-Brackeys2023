using UnityEngine;

[CreateAssetMenu(fileName = "GameController", menuName = "GameContoller/GameController", order = 1)]
public class GameController : ScriptableObject
{
    [Header("Game Pause Data")]
    [Tooltip("Move this variable to change the speed of the game, and set it to 0 to pause it completely")]
    [SerializeField] public float GameTime = 1;

    [Tooltip("Boolean that indicates if the game is paused")]
    [SerializeField] public bool isGamePaused;
    [Space(10)]

    [Header("Player Data")]
    [SerializeField] public float PlayerHP;
    [Tooltip("Move this to change the player max Speed")]
    [SerializeField] public float maxSpeed = 0;

    [Tooltip("Do NOT move this parameter to change the speed, move the one above")]
    [SerializeField] public float currentSpeed = 0;

    [Tooltip("Check If Player is inside the seaweeds")]
    [SerializeField] public bool Tangled;

    [Tooltip("Move this parameter to change the ammont of iFrames the playe gets")]
    [SerializeField] public float playerIFrames = 2f;
    
    [Tooltip("Do NOT move this parameter to change the iFrames, move the one above")]
    [SerializeField] public float activeIFrames = 0;

    [Tooltip("The position to respawn, DO NOT set it to anything")]
    [SerializeField] public Transform respawnPoint;
    [Space(10)]

    [Header("GameData")]

    [SerializeField] public float KeysAmount;
    [SerializeField] public float KeysObtained;
    [SerializeField] public float gameScore;
    [SerializeField] public float gameHighScore;

}
