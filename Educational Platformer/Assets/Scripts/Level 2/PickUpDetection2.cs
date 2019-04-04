using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDetection2 : MonoBehaviour
{
    public GameObject interactPrompt;
    bool interactCoolant = false;

    public GameObject nuclearProtectPrompt;
    bool nuclearProtect = false;

    public GameObject moderatorPrompt;
    bool moderator = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Coin"))
        {
            FindObjectOfType<GameSession2>().AddScore(50);
            FindObjectOfType<CoinSFX>().playCoinSFX();
            Destroy(gameObject);
        }
        else if (gameObject.name == interactPrompt.name && !interactCoolant)
        {
            FindObjectOfType<InGameMenuController>().JournalPause(gameObject);
            interactCoolant = true;
        }
        else if (gameObject.name == nuclearProtectPrompt.name && !nuclearProtect)
        {
            FindObjectOfType<InGameMenuController>().JournalPause(gameObject);
            nuclearProtect = true;
        }
        else if (gameObject.name == moderatorPrompt.name && !moderator)
        {
            FindObjectOfType<InGameMenuController>().JournalPause(gameObject);
            moderator = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Switch"))
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                FindObjectOfType<GameSession2>().ActivateSwitch(gameObject);
            }
        }
    }



}
