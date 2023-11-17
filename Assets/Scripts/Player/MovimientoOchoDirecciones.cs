using System;
using UnityEngine;


public class MovimientoOchoDirecciones : MonoBehaviour
{

    [SerializeField] InputSystem inputSystem;
    [SerializeField] GameController GM;
    Rigidbody2D rb;
    public float recoverySpeed = 0.5f;
    private Vector3 respawnPoint;




    void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();
        GM.currentSpeed = GM.maxSpeed;
        respawnPoint = transform.position;
    }

    void Update()
    {
        if((GM.currentSpeed < GM.maxSpeed) && !GM.Tangled)
        {
            GM.currentSpeed += recoverySpeed * Time.deltaTime * GM.GameTime;
        }
        else if(GM.currentSpeed > GM.maxSpeed)
        {
            GM.currentSpeed = GM.maxSpeed;
        }

        Inputs();
        
        if (GM.PlayerHP<=0){
            transform.position = respawnPoint;
            GM.PlayerHP=3;
        }

        if (GM.isBossActive==true){
            ControllAudio.Instance.PauseMusic();
        }
        
    }

    void Inputs()
    {
        inputSystem.xMove = Input.GetAxis("Horizontal");
        inputSystem.yMove = Input.GetAxis("Vertical");

 
        inputSystem.moveL = Input.GetKey(KeyCode.A);
        inputSystem.moveR = Input.GetKey(KeyCode.D);
        inputSystem.moveD = Input.GetKey(KeyCode.S);
        inputSystem.moveU = Input.GetKey(KeyCode.W);

        rb.velocity = new Vector2(inputSystem.xMove * GM.currentSpeed * GM.GameTime, inputSystem.yMove * GM.currentSpeed * GM.GameTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Key"){
            respawnPoint = transform.position;
        }

    }



}


