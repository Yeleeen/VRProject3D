using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPaused = false;
    public static bool GameIsOver = false;

    public GameObject pauseMenuUI;
    public GameObject gameMenuUI;
    public GameObject ScoreMenuUI;
    //public GameObject buttonUI;

    List<GameObject> UI = new List<GameObject>();
    UI.Add(pauseMenuUI);
    UI.Add(gameMenuUI);
    UI.Add(ScoreMenuUI);

    // Update is called once per frame
    void Update()
    {
        if (GameIsOver == true){
            UI[1].SetActive(false);
            UI[2].SetActive(true);
            
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();

            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        Debug.Log("Resume..");
        pauseMenuUI.SetActive(false);
        if (GameIsOver==true){
            UI[2].SetActive(true);
        }
        else{
            UI[1].SetActive(true);
        }
        //buttonUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        
        if (GameIsOver==true){
            UI[2].SetActive(false);
        }
        else{
            UI[1].SetActive(false);
        }
        //buttonUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        Debug.Log("Loading Menu..");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game..");
        Application.Quit();
    }
}
