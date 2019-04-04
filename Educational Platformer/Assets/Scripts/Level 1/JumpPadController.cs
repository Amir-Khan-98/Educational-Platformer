using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadController : MonoBehaviour
{
    
    public bool playerJumpAttempt = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       gameObject.GetComponent<Animator>().SetBool("PlayerJump", false);
        playerJumpAttempt = false;
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        playerJumpAttempt = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerJumpAttempt = false;
    }

    private void Update()
    {
        if(playerJumpAttempt){
            Jump();
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector2 playerVelocity = new Vector2(FindObjectOfType<Player>().myRigidBody.velocity.x, FindObjectOfType<Player>().myRigidBody.velocity.y);
            playerVelocity += new Vector2(0f, 39f);
            gameObject.GetComponent<Animator>().SetBool("PlayerJump", true);
            FindObjectOfType<Player>().myRigidBody.velocity = playerVelocity;
        }
    }



    
}
