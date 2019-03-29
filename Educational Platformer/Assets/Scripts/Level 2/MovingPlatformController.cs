using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{

    public GameObject platform;
    public GameObject switchTurnOn;
    public GameObject stopper;
    public static bool moving = false;
    
    // Start is called before the first frame update
    void Start()
    {
        

        if (FindObjectOfType<GameSession2>().switchTurbine == null)
        {
            FindObjectOfType<GameSession2>().switchTurbine = switchTurnOn;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            platform.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,7f);
            //Debug.Log("should be true");
        }
        else
        {
            platform.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        }
        //Debug.Log(moving);
    }
    public void SetMoving()
    {
        moving = true;
    }
    public void SetMovingFalse()
    {
        moving = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == platform)
        {
            moving = false;
        }
    }
}
