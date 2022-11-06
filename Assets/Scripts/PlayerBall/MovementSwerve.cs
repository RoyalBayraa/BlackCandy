using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSwerve : MonoBehaviour
{
    private TestBallController _testBC;
    [SerializeField] private float swerveSpeed = 0.5f;
    [SerializeField] private float maxSwerveAmount = 1f;

    private void Awake()
    {
        _testBC = GetComponent<TestBallController>();
    }

    private void Update()
    {
        float swerveAmount = Time.deltaTime * swerveSpeed * _testBC.MoveFingX;
        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
        transform.Translate(swerveAmount, 0, 0);
    }
}
