using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameMenuManager : MonoBehaviour
{
    public Button Button1;

    public void playCity()
    {
        SceneManager.LoadScene(0);
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        Button1.onClick.AddListener(delegate{playCity();});

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
