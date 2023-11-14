using UnityEngine;



[CreateAssetMenu(fileName = "InputReader", menuName = "Inputs / InputReader", order = 1)]
public class InputSystem : ScriptableObject
{
    public bool moveL, moveR, moveU, moveD;

    public float xMove, yMove;

}
