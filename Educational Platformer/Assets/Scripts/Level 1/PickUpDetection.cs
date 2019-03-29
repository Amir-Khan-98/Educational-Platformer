using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDetection : MonoBehaviour
{
    public GameObject interactPrompt;
    bool interactCoolant = false;

    public GameObject nuclearProtectPrompt;
    bool nuclearProtect = false;

    public GameObject moderatorPrompt;
    bool moderator = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //AudioSource.PlayClipAtPoint(coinPickUpSFX, Camera.main.transform.position);
        //GameSession.score += 50;

        if (gameObject.CompareTag("NRod"))
        {
            if (!FindObjectOfType<GameSession>().hazmatSuitObtained)
            {
                FindObjectOfType<Player>().myAnimator.SetTrigger("Dying");
                Vector2 playerVelocity = new Vector2(0, 0);
                FindObjectOfType<Player>().myRigidBody.velocity = playerVelocity;
                FindObjectOfType<Player>().isAlive = false;
                FindObjectOfType<GameSession>().ProcessPlayerDeath();
            }
            else
            {
                FindObjectOfType<GameSession>().AddRods("NRod");
                Destroy(gameObject);
            }
        }

            
        else if (gameObject.CompareTag("CRod"))
        {
            FindObjectOfType<GameSession>().AddRods("CRod");
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("Coin"))
        {
            FindObjectOfType<GameSession>().AddScore(50);
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("HazmatSuit"))
        {
            FindObjectOfType<GameSession>().CollectHazmat();
            Destroy(gameObject);
        }
        else if (gameObject.name == interactPrompt.name && !interactCoolant)
        {
            FindObjectOfType<InGameMenuController>().JournalPause(gameObject);
            interactCoolant = true;
           // Destroy(gameObject);
        }
        else if (gameObject.name == nuclearProtectPrompt.name && !nuclearProtect)
        {
            FindObjectOfType<InGameMenuController>().JournalPause(gameObject);
            nuclearProtect = true;
            // Destroy(gameObject);
        }
        else if (gameObject.name == moderatorPrompt.name && !moderator)
        {
            FindObjectOfType<InGameMenuController>().JournalPause(gameObject);
            moderator = true;
        }

        // FindObjectOfType<GameSession>().AddRods(1);
        // Destroy(gameObject);

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Switch"))
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                FindObjectOfType<GameSession>().ActivateSwitch(gameObject);
            }
            //Debug.Log("chewking switch");
        }
        
    }



}
