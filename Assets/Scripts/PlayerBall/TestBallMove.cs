using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBallMove : MonoBehaviour
{
    private float moveSpeed = 3;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
    }
}