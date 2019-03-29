using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController2 : MonoBehaviour
{

    GameObject currentObject;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Checkpoint"))
        {
            currentObject = gameObject;
            FindObjectOfType<GameSession2>().currentCheckpointObject = currentObject;
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Checkpoint"))
        {
            currentObject = gameObject;
            FindObjectOfType<GameSession2>().currentCheckpointObject = currentObject;
        }
    }

    public GameObject GetObject()
    {
        return currentObject;
    }





}
