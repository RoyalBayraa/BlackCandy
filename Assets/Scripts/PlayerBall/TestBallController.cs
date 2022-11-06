using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestBallController : MonoBehaviour
{


    public int coins;
    public Text coinCounter;

    private float _lastTouchPosX;
    private float _moveFingX;
    public float MoveFingX => _moveFingX;

    // Start is called before the first frame update
    void Start()
    {
        coins = 0;
        coinCounter.text = "Coins: " + coins;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            _lastTouchPosX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            _moveFingX = Input.mousePosition.x - _lastTouchPosX;
            _lastTouchPosX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _moveFingX = 0f;
        }
    }
    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Coin")
        {
            Destroy(col.gameObject);
            coins++;
            coinCounter.text = "Coins: " + coins;
        }

        if(col.gameObject.tag == "FinishLevel")
        {
            FinishLevel();
            
        }
    }

 

    public void FinishLevel()
    {
        if (coins >= 10)
        {
            Debug.Log("Complete level");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Debug.Log("Reset Level");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
