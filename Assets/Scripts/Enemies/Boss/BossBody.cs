using System.Collections.Generic;
using UnityEngine;


public class BossBody : MonoBehaviour
{
    [SerializeField] Transform bossBody;
    public float circleDiameter;

    [SerializeField]List<Transform> bossPart = new List<Transform>();
    [SerializeField]List<Vector2> bossPos = new List<Vector2>();
    void Start()
    {
        bossPos.Add(bossBody.position);
    }

    // Update is called once per frame
    void Update()
    {
        float dist = ((Vector2) bossBody.position - bossPos[0]).magnitude;

        

        if(dist > circleDiameter)
        {
            Vector2 direction = ((Vector2)bossBody.position - bossPos[0]).normalized;
            
            bossPos.Insert(0, bossPos[0] + direction * circleDiameter);
            bossPos.RemoveAt(bossPos.Count -1);

            dist -= circleDiameter;
        }

        for(int i = 0; i < bossPart.Count; i++)
        {
            bossPart[i].position = Vector2.Lerp(bossPos[i + 1], bossPos[i], dist/circleDiameter);
        }
    }
}
