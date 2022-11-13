using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCameraController : MonoBehaviour
{
    public Transform playerBall;
    

    private float yOffset = 1f;
    private float zOffset = -3f;
    // Start is called before the first frame update
    void Start()
    {
        playerBall = GameObject.Find("PlayerBall").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(playerBall.position.x, playerBall.position.y + yOffset,playerBall.position.z + zOffset);
    }

    
}
