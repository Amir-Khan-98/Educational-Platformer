using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{

    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;
    int scoreToLife = 0;
    int nuclearRodNum = 0;
    int controlRodNum = 0;
    readonly String nuclearRodTag = "NRod";
    readonly String controlRodTag = "CRod";
    readonly String switchTag = "Switch";

    [SerializeField] Text livesText;
    [SerializeField] Text scoreText;
    [SerializeField] Text nuclearRodText;
    [SerializeField] Text controlRodText;
    [SerializeField] Text switchCoolantText;

    bool switchOnCoolant = false;
    public bool hazmatSuitObtained = false;
    //game objects
    public GameObject switchCoolant;

    public GameObject radioactiveProtection;
    //Start of tutorial

    public GameObject currentCheckpointObject;

    public bool firstSpawn = true;
    public bool win = false;

    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        
    }
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
        nuclearRodText.text = nuclearRodNum.ToString() + " / 3";
        controlRodText.text = controlRodNum.ToString() + " / 3";
        
    }
    public void AddScore(int points)
    {
        score += points;
        scoreToLife += points;
        scoreText.text = score.ToString();
        if (scoreToLife >= 1000)
        {
            AddLife();
            scoreToLife -= 1000;
        }

    }
    public Text GetScore()
    {
        return scoreText;
    }
    public void AddRods(String type)
    {
        if (type == nuclearRodTag)
        {
            nuclearRodNum++;
            nuclearRodText.text = nuclearRodNum.ToString() + " / 3";
            if (nuclearRodNum == 1)
            {
                FindObjectOfType<InGameMenuController>().JournalPause(nuclearRodTag);
            }
            if (nuclearRodNum == 3)
            {
                nuclearRodText.color = Color.green;
            }
        }
        else if (type == controlRodTag)
        {
            controlRodNum++;
            controlRodText.text = controlRodNum.ToString() + " / 3";
            if (controlRodNum == 1)
            {
                FindObjectOfType<InGameMenuController>().JournalPause(controlRodTag);
            }
            if (controlRodNum == 3)
            {
                controlRodText.color = Color.green;
            }
        }
    }
    public void ActivateSwitch(GameObject switch1)
    {
        if (switchOnCoolant == false && switch1.name == switchCoolant.name)
        {
            switchOnCoolant = true;
            switchCoolantText.text = "1 / 1";
            switchCoolantText.color = Color.green;
            switch1.GetComponent<Animator>().SetBool("SwitchOn", switchOnCoolant);
            FindObjectOfType<InGameMenuController>().JournalPause(switchTag);
            switch1.GetComponent<CapsuleCollider2D>().enabled = false;
            switch1.transform.Find("Barrier").gameObject.SetActive(false);

            switch1.transform.Find("Off").gameObject.SetActive(false);
            switch1.transform.Find("On").gameObject.SetActive(true);
            //add switch function
        }
    }

    public void CollectHazmat()
    {
        hazmatSuitObtained = true;
        radioactiveProtection.SetActive(true);
    }
    public void HazmatFollowPlayer()
    {
        Vector2 playerVel = FindObjectOfType<Player>().player.transform.position;

        radioactiveProtection.transform.position = playerVel - new Vector2(0f,0.5f);
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            //ResetGameSession();
            EndLevel();
        }
    }

    private void TakeLife()
    {
        playerLives--;
        livesText.text = playerLives.ToString();
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        firstSpawn = false;
    }
    private void AddLife()
    {
        playerLives++;
        livesText.text = playerLives.ToString();
    }
    
    public Vector2 GetRespawnPoint()
    {
       // currentCheckpointObject = FindObjectOfType<CheckpointController>().GetObject();
        Vector2 respawnPoint;

        respawnPoint = currentCheckpointObject.transform.position;


        return respawnPoint;
    }
    public void EndLevel()
    {
        if (win)
        {
            SceneManager.LoadScene(4);
        }
        else
        {
            SceneManager.LoadScene(6);
        }
    }

    public void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
