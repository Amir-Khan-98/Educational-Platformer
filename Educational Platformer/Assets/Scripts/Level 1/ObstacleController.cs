using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    //Tilemaps linked with waste
    public GameObject waste1;
    Vector2 waste1Pos;
    public GameObject waste2;
    Vector2 waste2Pos;
    public GameObject waste3;
    Vector2 waste3Pos;
    public GameObject waste4;
    Vector2 waste4Pos;
    public GameObject waste5;
    Vector2 waste5Pos;
    public GameObject waste6;
    Vector2 waste6Pos;
    public GameObject waste7;
    Vector2 waste7Pos;
    public GameObject waste8;
    Vector2 waste8Pos;
    public GameObject waste9;
    Vector2 waste9Pos;
    public GameObject waste10;
    Vector2 waste10Pos;
    public GameObject waste11;
    Vector2 waste11Pos;

    public Vector2 velocity = new Vector2(0f,-5f);
    


    // Start is called before the first frame update
    void Start()
    {
        waste1Pos = waste1.transform.position;
        waste1.GetComponent<Rigidbody2D>().velocity = velocity;

        waste2Pos = waste2.transform.position;
        waste2.GetComponent<Rigidbody2D>().velocity = velocity;

        waste3Pos = waste3.transform.position;
        waste3.GetComponent<Rigidbody2D>().velocity = velocity;

        waste4Pos = waste4.transform.position;
        waste4.GetComponent<Rigidbody2D>().velocity = velocity;

        waste5Pos = waste5.transform.position;
        waste5.GetComponent<Rigidbody2D>().velocity = velocity;

        waste6Pos = waste6.transform.position;
        waste6.GetComponent<Rigidbody2D>().velocity = velocity;

        waste7Pos = waste7.transform.position;
        waste7.GetComponent<Rigidbody2D>().velocity = velocity;

        waste8Pos = waste8.transform.position;
        waste8.GetComponent<Rigidbody2D>().velocity = velocity;

        waste9Pos = waste9.transform.position;
        waste9.GetComponent<Rigidbody2D>().velocity = velocity;

        waste10Pos = waste10.transform.position;
        waste10.GetComponent<Rigidbody2D>().velocity = velocity;

        waste11Pos = waste11.transform.position;
        waste11.GetComponent<Rigidbody2D>().velocity = velocity;








    }
     // Update is called once per frame

    void Update()
    {
        /*
        waste1.GetComponent<Rigidbody2D>().velocity = velocity;

        
        waste2.GetComponent<Rigidbody2D>().velocity = velocity;

        
        waste3.GetComponent<Rigidbody2D>().velocity = velocity;

        
        waste4.GetComponent<Rigidbody2D>().velocity = velocity;

        
        waste5.GetComponent<Rigidbody2D>().velocity = velocity;

        
        waste6.GetComponent<Rigidbody2D>().velocity = velocity;

       
        waste7.GetComponent<Rigidbody2D>().velocity = velocity;

        
        waste8.GetComponent<Rigidbody2D>().velocity = velocity;

        
        waste9.GetComponent<Rigidbody2D>().velocity = velocity;

        
        waste10.GetComponent<Rigidbody2D>().velocity = velocity;

        
        waste11.GetComponent<Rigidbody2D>().velocity = velocity;
        */
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == waste1)
        {
            collision.gameObject.transform.position = waste1Pos + new Vector2(0f,1f);
        }
        else if (collision.gameObject == waste2)
        {
            collision.gameObject.transform.position = waste2Pos;
        }
        else if (collision.gameObject == waste3)
        {
            collision.gameObject.transform.position = waste3Pos - new Vector2(0f, 1f);
        }
        else if (collision.gameObject == waste4)
        {
            collision.gameObject.transform.position = waste4Pos - new Vector2(0f, 2f);
        }
        else if (collision.gameObject == waste5)
        {
            collision.gameObject.transform.position = waste5Pos - new Vector2(0f, 3f);
        }
        else if (collision.gameObject == waste6)
        {
            collision.gameObject.transform.position = waste6Pos - new Vector2(0f, 4f);
        }
        else if (collision.gameObject == waste7)
        {
            collision.gameObject.transform.position = waste7Pos - new Vector2(0f, 5f);
        }
        else if (collision.gameObject == waste8)
        {
            collision.gameObject.transform.position = waste8Pos - new Vector2(0f, 6f);
        }
        else if (collision.gameObject == waste9)
        {
            collision.gameObject.transform.position = waste9Pos - new Vector2(0f, 7f);
        }
        else if (collision.gameObject == waste10)
        {
            collision.gameObject.transform.position = waste10Pos - new Vector2(0f, 8f);
        }
        else if (collision.gameObject == waste11)
        {
            collision.gameObject.transform.position = waste11Pos - new Vector2(0f, 9f);
        }



    }

}
