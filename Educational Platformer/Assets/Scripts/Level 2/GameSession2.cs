using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession2 : MonoBehaviour
{

    [SerializeField] int playerLives = 50;
    [SerializeField] int score = 0;
    int scoreToLife = 0;
    int switchNum = 0;
    public bool win = false;
    readonly String switchTag = "Switch";

    [SerializeField] Text livesText;
    [SerializeField] Text scoreText;
    
    [SerializeField] Text switchText;

    bool switchOnInjectionWell = false;
    bool switchOnHotWater = false;
    bool switchOnTurbine = false;
    //game objects
    public GameObject switchInjectionWell;
    public GameObject switchHotWater;
    public GameObject switchTurbine;
   
    //Start of tutorial

    public GameObject currentCheckpointObject;

    public bool firstSpawn = true;

    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession2>().Length;
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
        

    }
    public void AddScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();
        scoreToLife += points;
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
    
    public void ActivateSwitch(GameObject switch1)
    {
        if (switchOnInjectionWell == false && switch1.name == switchInjectionWell.name)
        {
            switchOnInjectionWell = true;
            switchNum++;
            switchText.text = switchNum.ToString() + " / 3";
            //switchText.color = Color.green;
            switch1.GetComponent<Animator>().SetBool("SwitchOn", switchOnInjectionWell);
            FindObjectOfType<InGameMenuController>().JournalPause(switchTag);
            switch1.GetComponent<CapsuleCollider2D>().enabled = false;
            switch1.transform.Find("Barrier").gameObject.SetActive(false);

            switch1.transform.Find("Off").gameObject.SetActive(false);
            switch1.transform.Find("On").gameObject.SetActive(true);
            //add switch function
        }
        else if (!switchOnHotWater && switch1.name == switchHotWater.name)
        {
            switchOnInjectionWell = true;
            switchNum++;
            switchText.text = switchNum.ToString() + " / 3";
            FindObjectOfType<InGameMenuController>().JournalPause(switchTag+"1");
            switch1.transform.Find("Off").gameObject.SetActive(false);
            switch1.transform.Find("On").gameObject.SetActive(true);
        }
        else if (switch1.name == switchTurbine.name)
        {
            switchOnTurbine = true;
            if (switchNum != 3)switchNum++;
            switchText.color = Color.green;
            switchText.text = switchNum.ToString() + " / 3";
            FindObjectOfType<MovingPlatformController>().SetMoving(); 
            
        }

    }

    
    

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
            //FindObjectOfType<MovingPlatformController>().moving = false;
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
        FindObjectOfType<MovingPlatformController>().SetMovingFalse();

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
