using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public GameObject playerObject; 
    float horizontalMove = 0f;
    float _speed = 8f;
    bool _jump = false;
    public Rigidbody2D m_Rigidbody2D;
    public GameObject gameOverCanvas;
    public GameObject gameCanvas;
    bool midAir = false;
    bool canDoubleJump = true; 
    int click_count = 0;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        if (playerObject != null)
            playerObject.transform.Translate(Vector3.right * Time.deltaTime * _speed);
        if (_jump && !midAir)
        {
            jump();
            midAir = true;

          
        }
        //if (midAir == true)
        //{
        //    jump();
        //    midAir = false;

        //}
        if (m_Rigidbody2D.velocity.y == 0)
        {
            midAir = false;
        }
    }
    public void onJumpClick(){
        _jump = true;
    }

    // Destroys the gameObject and ReInitiates the game
    void LateUpdate(){
        Vector3 playerPos = playerObject.transform.position;
        if (playerPos.y < -30f){
            Destroy(playerObject);
            gameOverCanvas.SetActive(true);
            gameCanvas.SetActive(false);
        }
    }
    void jump(){
          m_Rigidbody2D.velocity = Vector3.up * controller.m_JumpForce;
          _jump = false;
          canDoubleJump = false;  
    }
}
