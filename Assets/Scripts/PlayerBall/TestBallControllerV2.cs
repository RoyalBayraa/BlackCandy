using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestBallControllerV2 : MonoBehaviour
{
    public RoadSpawner roadSpawner;
    
    private Transform ball;
    private Vector3 startMousePos, startBallPos;
    private bool moveTheBall;
    [Range (0f,1f) ]public float maxSpeed;
    [Range (0f,1f) ]public float camSpeed;
    [Range (0f,50f) ]public float pathSpeed;
    private float velocity, camVelocity;
    private Camera mainCam;
    public Transform path;
    public GameObject FinishLine;

    private float moveSpeed = 5f;
    private float moveSpeedMax = 15f;

    private int levelNubmer = 1;

    private int coin = 0;

    void Start()
    {
        ball = transform;
        mainCam = Camera.main;
    }

    
    void Update()
    {

        MenuManager.MenuManagerInstance.menuElement[4].GetComponent<Text>().text = PlayerPrefs.GetInt("level", 0).ToString();
        if (Input.GetMouseButtonDown(0) && MenuManager.MenuManagerInstance.GameState)
        {
            moveTheBall = true;

            Plane newPlan = new Plane(Vector3.up, 0f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(newPlan.Raycast(ray,out var distance))
            {
                startMousePos = ray.GetPoint(distance);
                startBallPos = ball.position;
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            moveTheBall = false;
        }

        if (moveTheBall)
        {
            Plane newPlan = new Plane(Vector3.up, 0f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (newPlan.Raycast(ray, out var distance))
            {
                Vector3 mouseNewPos = ray.GetPoint(distance);
                Vector3 MouseNewPos = mouseNewPos - startMousePos;
                Vector3 DesireBallPos = MouseNewPos + startBallPos;

                DesireBallPos.x = Mathf.Clamp(DesireBallPos.x, -1.6f, 1.6f);

                moveSpeed += 1;
                if(moveSpeed >= moveSpeedMax)
                {
                    moveSpeed = moveSpeedMax;
                }

                ball.position = new Vector3(Mathf.SmoothDamp(ball.position.x, DesireBallPos.x, ref velocity, maxSpeed), ball.position.y, ball.position.z + moveSpeed * Time.deltaTime);

            }
        }

        //if (MenuManager.MenuManagerInstance.GameState)
        //{
        //var pathNewPos = path.position;
        //path.position = new Vector3(pathNewPos.x, pathNewPos.y, Mathf.MoveTowards(pathNewPos.z, -1000f, pathSpeed * Time.deltaTime));

        //}

        



    }
    private void LateUpdate()
    {
        var CameraNewPos = mainCam.transform.position;
        if (moveTheBall)
        {
            mainCam.transform.position = new Vector3(Mathf.SmoothDamp(CameraNewPos.x, ball.transform.position.x, ref camVelocity, camSpeed), CameraNewPos.y, CameraNewPos.z + moveSpeed * Time.deltaTime);
        }

    }

    public void OnTriggerEnter(Collider coll)
    {

        if (coll.CompareTag("Saad"))
        {
            gameObject.SetActive(false);
            MenuManager.MenuManagerInstance.GameState = false;
            MenuManager.MenuManagerInstance.menuElement[2].SetActive(true);
            MenuManager.MenuManagerInstance.menuElement[2].transform.GetChild(0).GetComponent<Text>().text = "You Lose";
        }

        if (coll.gameObject.tag == "Coin")
        {
            Destroy(coll.gameObject);
            coin++;
            //MenuManager.MenuManagerInstance.menuElement[4].GetComponent<Text>().text = levelNubmer.ToString();
            MenuManager.MenuManagerInstance.menuElement[1].GetComponent<Text>().text = coin.ToString();
            if(coin > PlayerPrefs.GetInt("Onoo", 0))
            {
                PlayerPrefs.SetInt("Onoo", coin);
                MenuManager.MenuManagerInstance.menuElement[3].GetComponent<Text>().text = coin.ToString();
            }

            if(levelNubmer > PlayerPrefs.GetInt("level", 0))
            {
                PlayerPrefs.SetInt("level", levelNubmer);
                MenuManager.MenuManagerInstance.menuElement[5].GetComponent<Text>().text = levelNubmer.ToString();
            }

            if (coin >= 20)
            {
                coin = 0;
                levelNubmer++;
                PlayerPrefs.SetInt("level", levelNubmer);
                Debug.Log("Next Level");
            }
        }

        if(coll.gameObject.tag == "FinishLevel")
        {
            coin = 0;
            levelNubmer++;

           
            FinishLine.SetActive(false);
        }
       
    }

    
}
