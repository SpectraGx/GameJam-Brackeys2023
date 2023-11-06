using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "InputReader", menuName = "Inputs / InputReader", order = 1)]
public class InputSystem : ScriptableObject
{
    public bool moveR, moveL, moveU, moveD;

    public float xMove, yMove;

}
