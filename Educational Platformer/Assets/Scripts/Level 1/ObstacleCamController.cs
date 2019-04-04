using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCamController : MonoBehaviour
{
    public static bool cameraOn;
    public static bool cameraOn2;
    public static bool cameraOn3;
    public Cinemachine.CinemachineVirtualCamera cam;
    float originalSize;
    float obstacleSize = 10f;
    // Start is called before the first frame update
    void Start()
    {
        cameraOn = false;
        cameraOn2 = false;
        cameraOn3 = false;
        originalSize = cam.m_Lens.OrthographicSize;
    }

    // Update is called once per frame
    
    void Update()
    {
        if (cameraOn || cameraOn2 || cameraOn3)
        {
            ChangeCamSize();
        }
        else if (!cameraOn && !cameraOn2 && !cameraOn3)
        {
            ChangeCamSizeSmall();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.name == "ObstacleCamOn")
        {
            cameraOn = true;
        }
        else if (gameObject.name == "ObstacleCamOn2")
        {
            cameraOn2 = true;
        }
        else if (gameObject.name == "ObstacleCamOn3")
        {
            cameraOn3 = true;
        }
        else if (gameObject.name == "ObstacleCamOff")
        {
            cameraOn = false;
            cameraOn2 = false;
            cameraOn3 = false;
        }
    }
    private void ChangeCamSize()
    {
        if (cameraOn && !cameraOn2 && !cameraOn3 && cam.m_Lens.OrthographicSize < obstacleSize + 4f)
        {
            cam.m_Lens.OrthographicSize += 0.1f;
        }
        else if (cameraOn2 && !cameraOn3 && !cameraOn && cam.m_Lens.OrthographicSize < obstacleSize + 10f)
        {
            cam.m_Lens.OrthographicSize += 0.3f;
        }
        else if (cameraOn3 && !cameraOn && !cameraOn2 && cam.m_Lens.OrthographicSize < obstacleSize + 10f)
        {
            cam.m_Lens.OrthographicSize += 0.2f;
        }
    }
    private void ChangeCamSizeSmall()
    {
        if ((!cameraOn && !cameraOn2 && !cameraOn3) && cam.m_Lens.OrthographicSize > originalSize)
        {
            cam.m_Lens.OrthographicSize -= 0.05f;
        }
    }
}
