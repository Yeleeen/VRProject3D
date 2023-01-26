using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameMenuManager : MonoBehaviour
{
    public Button ButtonCity;
    public Button ButtonResto;
    public Button ButtonClass;

    public void playCity()
    {
        SceneManager.LoadScene(1);
    }

    public void playResto()
    {
        SceneManager.LoadScene(3);
    }

    public void playClass()
    {
        SceneManager.LoadScene(2);
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        ButtonCity.onClick.AddListener(delegate{playCity();});
        ButtonResto.onClick.AddListener(delegate{playResto();});
        ButtonClass.onClick.AddListener(delegate{playClass();});

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
