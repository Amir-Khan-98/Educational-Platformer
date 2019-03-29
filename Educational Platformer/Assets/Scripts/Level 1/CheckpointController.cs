using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{

     GameObject currentObject;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Checkpoint"))
        {
            currentObject = gameObject;
            FindObjectOfType<GameSession>().currentCheckpointObject = currentObject;
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Checkpoint"))
        {
            currentObject = gameObject;
            FindObjectOfType<GameSession>().currentCheckpointObject = currentObject;
        }
    }

    public GameObject GetObject()
    {
        return currentObject;
    }

    

    

}
