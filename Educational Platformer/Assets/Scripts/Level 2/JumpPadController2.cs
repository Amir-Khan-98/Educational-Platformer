using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadController2 : MonoBehaviour
{

    bool playerJumpAttempt = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.GetComponent<Animator>().SetBool("PlayerJump", false);
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
        if (playerJumpAttempt)
        {
            Jump();
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector2 playerVelocity = new Vector2(FindObjectOfType<Player2>().myRigidBody.velocity.x, 39f);
            gameObject.GetComponent<Animator>().SetBool("PlayerJump", true);
            FindObjectOfType<Player2>().myRigidBody.velocity = playerVelocity;
        }
    }
}
