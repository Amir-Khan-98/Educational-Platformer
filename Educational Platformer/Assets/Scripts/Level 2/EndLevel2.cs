using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndLevel2 : MonoBehaviour
{

    public Text finalScoreText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<GameSession2>().win = true;
        FindObjectOfType<GameSession2>().EndLevel();
    }

    private void Start()
    {
        finalScoreText.text = "Your score was: " + FindObjectOfType<GameSession2>().GetScore().text;
        
        Destroy(FindObjectOfType<GameSession2>().gameObject);
    }
}
