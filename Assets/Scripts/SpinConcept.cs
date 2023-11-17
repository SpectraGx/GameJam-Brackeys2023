using System.Collections;
using UnityEngine;

public class SpinConcept : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField] float timeFlash = 0.8f;
    
    
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Start()
    {

        StartCoroutine(ScreenTintineo());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator ScreenTintineo()
    {
        for(;;)
        {
            if (spriteRenderer.color != new Color(1, 1, 1, 1))
            {
                spriteRenderer.color = new Color(1, 1, 1, 1);
            }
            else
            {
                spriteRenderer.color = new Color(1, 1, 1, 0.5f);
            }
            yield return new WaitForSeconds(timeFlash);
        }
    }
}
