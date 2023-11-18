using UnityEngine;
using TMPro;

public class WinScore : MonoBehaviour
{
    [SerializeField] GameController GM;
    [SerializeField] TextMeshProUGUI PartsCount;
    [SerializeField] TextMeshProUGUI DeathCount;
    [SerializeField] TextMeshProUGUI TotalScore;
    void Start()
    {
        PartsCount.text = "x " + GM.PartsCount + " = " + GM.PartsCount * 1000;
        DeathCount.text = "x " + GM.DeathCount + " = " + GM.DeathCount * -1000;
        TotalScore.text = "Final Score = " + (10000 + (GM.PartsCount * 1000) + (GM.DeathCount * -1000));
    }


}
