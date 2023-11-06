using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tesoros : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D Collision){

        if(Collision.gameObject.tag == "nave")
        {
            Destroy(this.gameObject);

        }

    }

}
