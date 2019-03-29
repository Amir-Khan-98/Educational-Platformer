using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreventDeath : MonoBehaviour
{

    public bool isPlayerSafe;


    private void Start()
    {
        isPlayerSafe = false;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerSafe = true;
        }
        
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        isPlayerSafe = false;
    }


    public bool GetBool()
    {
        return isPlayerSafe;
    }

}
