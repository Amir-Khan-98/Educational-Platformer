using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenuController : MonoBehaviour
{
    //public string mainMenuScene;
    public GameObject journalPopUpNRod;
    public GameObject journalPopUpCRod;
    public GameObject journalPopUpSwitchCoolant;
    public GameObject interactPromptSwitchCoolant;
    public GameObject nuclearProtoectPrompt;
    public GameObject journalPopUpModerator;
    public GameObject pauseMenu;
    public bool isPaused;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }


    }

    public void Resume()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        journalPopUpNRod.SetActive(false);
        journalPopUpCRod.SetActive(false);
        journalPopUpSwitchCoolant.SetActive(false);
        interactPromptSwitchCoolant.SetActive(false);
        nuclearProtoectPrompt.SetActive(false);
        journalPopUpModerator.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        isPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void JournalPause(string tag)
    {
        isPaused = true;
        Time.timeScale = 0f;
        if (tag == "NRod")
        {
            journalPopUpNRod.SetActive(true);
        }
        else if (tag == "CRod")
        {
            journalPopUpCRod.SetActive(true);
        }
        else if (tag == "Switch")
        {
            journalPopUpSwitchCoolant.SetActive(true);
        }
        else if (tag == "Switch1")
        {
            journalPopUpCRod.SetActive(true);
        }
        else if (tag == "Switch2")
        {
            journalPopUpNRod.SetActive(true);
        }
        
        
    }
    public void JournalPause(GameObject other)
    {
        isPaused = true;
        Time.timeScale = 0f;
        if (other.name == FindObjectOfType<PickUpDetection>().interactPrompt.name)
        {
            interactPromptSwitchCoolant.SetActive(true);
        }
        else if (other.name == FindObjectOfType<PickUpDetection>().nuclearProtectPrompt.name)
        {
            nuclearProtoectPrompt.SetActive(true);

        }
        else if (other.name == FindObjectOfType<PickUpDetection>().moderatorPrompt.name)
        {
            journalPopUpModerator.SetActive(true);
        }
    }
    public void JournalResume()
    {
        isPaused = false;
        journalPopUpNRod.SetActive(false);
        journalPopUpCRod.SetActive(false);
        journalPopUpSwitchCoolant.SetActive(false);
        interactPromptSwitchCoolant.SetActive(false);
        nuclearProtoectPrompt.SetActive(false);
        journalPopUpModerator.SetActive(false);
        Time.timeScale = 1f;
    }

    public void GoToMainMenu()
    {

        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        Resume();
        //FindObjectOfType<GameSession>().ResetGameSession();
        int numGameSessions = FindObjectsOfType<GameSession2>().Length;
        if (numGameSessions > 0)
        {
            Destroy(FindObjectOfType<GameSession2>().gameObject);
        }
        else
        {
            Destroy(FindObjectOfType<GameSession>().gameObject);
        }
        
        
        
    }

}
