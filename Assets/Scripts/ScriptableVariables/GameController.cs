using UnityEngine;

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

    [Tooltip("The position to respawn, DO NOT set it to anything")]
    [SerializeField] public Transform respawnPoint;
    [Space(10)]

    [Header("GameData")]

    [SerializeField] public float KeysAmount;
    [SerializeField] public float KeysObtained;
    [SerializeField] public float gameScore;
    [SerializeField] public float gameHighScore;

}
