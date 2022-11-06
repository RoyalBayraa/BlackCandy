using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChange : MonoBehaviour
{
    private TestBallController _TestBC;
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "PlayerBall")
        {
            _TestBC.FinishLevel();
        }
    }
}
