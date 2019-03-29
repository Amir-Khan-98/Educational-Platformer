using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndLevel : MonoBehaviour
{

    public Text finalScoreText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<GameSession>().win = true;
        FindObjectOfType<GameSession>().EndLevel();
    }

    private void Start()
    {
        finalScoreText.text = "Your score was: " + FindObjectOfType<GameSession>().GetScore().text;
        Destroy(FindObjectOfType<GameSession>().gameObject);
    }
}
