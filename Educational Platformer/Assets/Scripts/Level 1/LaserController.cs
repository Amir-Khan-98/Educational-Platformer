using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public GameObject laser;
    public float speed = 10f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        if (laser.name == "HorizontalRay")
        {
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0f);
        }
        else if (laser.name == "VerticalRay")
        {
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, speed);
        }
        
    }

    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.name == "HorizontalRay")
        {
            laser.GetComponent<Rigidbody2D>().velocity = laser.GetComponent<Rigidbody2D>().velocity * new Vector2(-1f,-0f);
        }
        else if (collision.name == "VerticalRay")
        {
            laser.GetComponent<Rigidbody2D>().velocity = laser.GetComponent<Rigidbody2D>().velocity * new Vector2(-0f, -1f);
        }
        
    }
}
