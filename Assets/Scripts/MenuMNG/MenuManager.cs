using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager MenuManagerInstance;
    public bool GameState;
    public GameObject[] menuElement = new GameObject[2];
    void Start()
    {
        GameState = false;
        MenuManagerInstance = this;

        MenuManager.MenuManagerInstance.menuElement[3].GetComponent<Text>().text = PlayerPrefs.GetInt("Onoo", 0).ToString();
        MenuManager.MenuManagerInstance.menuElement[5].GetComponent<Text>().text = PlayerPrefs.GetInt("level", 0).ToString();
    }

    void Update()
    {
        
    }

    public void StartTheGame()
    {
        GameState = true;
        menuElement[0].SetActive(false);
    }

    public void TryAgain_btn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
