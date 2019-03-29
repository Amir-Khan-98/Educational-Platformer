using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalObstacle : MonoBehaviour
{

    public GameObject nuclearWaste;
    public Vector2 velocity = new Vector2(0f,5f);

    public GameObject initialTrigger;
    public GameObject firstSpeedUp;
    public GameObject firstSpeedUp2;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.name == initialTrigger.name)
        {
            nuclearWaste.GetComponent<Rigidbody2D>().velocity = velocity;
            gameObject.transform.Find("Gate").gameObject.SetActive(true);
        }
        else if (gameObject.name == firstSpeedUp.name || gameObject.name == firstSpeedUp2.name)
        {
            velocity = velocity + new Vector2(0f,0.5f);
            nuclearWaste.GetComponent<Rigidbody2D>().velocity = velocity;
        }

        
    }
}
