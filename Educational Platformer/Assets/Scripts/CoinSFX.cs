using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSFX : MonoBehaviour
{
    public AudioClip coinPickUpSFX;
    float volume;
    private void Start()
    {
        volume = 0.5f;
    }
    
    // Start is called before the first frame update
    public void playCoinSFX()
    {
        
        AudioSource.PlayClipAtPoint(coinPickUpSFX, Camera.main.transform.position);
    }
}
