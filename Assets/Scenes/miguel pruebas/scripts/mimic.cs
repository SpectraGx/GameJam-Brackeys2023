using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class mimic : MonoBehaviour
{
    public int MChance;
    public int TSize;
    public float ScoreVar;


    void Awake()
    {
        MimicChance();
    }
    void Start()
    {
        switch (MChance)
        {
            case 0:
            {
                switch (TSize)
                {
                    case 0:
                    {
                        //Pequeño asi que suma 10 puntos;
                        ScoreVar = 10;
                        // Cambia Anim a T Small

                        break;
                    }

                    case 1:
                    {
                        //Pequeño asi que suma 20 puntos;
                        // Cambia Anim a T Med

                        break;
                    }

                    case 2:
                    {
                        //Grande asi que suma 30 puntos;
                        // Cambia Anim a T Big

                        break;
                    }
                }

                break;
            }
            case 1:
            {
                //Aqui es un mimic
                ScoreVar = Random.Range(0, -30);
                switch (TSize)
                {
                    case 0:
                    
                    // Cambia Anim a T Small

                    break;

                    case 1:

                    // Cambia Anim a T Med

                    break;

                    case 2:

                    // Cambia Anim a T Big

                    break;
                }



                break;
            }


        }
    }

    // Update is called once per frame
    void Update()
    {
        

        
    }

    private void OnTriggerEnter2D(Collider2D Collision)
    {

        if(Collision.gameObject.tag == "nave")
        {
            Destroy(this.gameObject);

        }

    }

    void ScoreUpdate()
    {
        //Score += ScoreVar
    }



    void MimicChance()
    {
        MChance = Random.Range(0,1);
        TSize = Random.Range(0,2);
    }
}


