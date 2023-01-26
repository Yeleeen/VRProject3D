using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class InsideMenu : MonoBehaviour
{

    public GameObject questionCanva;
    public GameObject pauseMenuCanva;
    public Button questionMenuButton;
    public Button pauseMenuButton;
    public Button resumeMenuButton;
    public Button leaveMenuButton;




    // Start is called before the first frame update
    void Start()
    {
      
      Debug.Log("start");

       questionMenuButton.onClick.AddListener(HideQuestionCanvas);
        pauseMenuButton.onClick.AddListener(HideMenuCanvas);

        resumeMenuButton.onClick.AddListener(HideMenuCanvas);

        leaveMenuButton.onClick.AddListener(SceneMenu);
         
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    void HideQuestionCanvas()
    {
        
        Debug.Log("HideQuestion");
        questionCanva.SetActive(false);
        pauseMenuCanva.SetActive(true);
    }
    void HideMenuCanvas()
    {
        Debug.Log("HideMenu");

        pauseMenuCanva.SetActive(false);
        questionCanva.SetActive(true);
    }

    void SceneMenu(){
        Debug.Log("HomeMenu");
        SceneManager.LoadScene(0); 
    }
}
