using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScores : MonoBehaviour
{

    public TextMeshProUGUI CityScore;
    public TextMeshProUGUI RestoScore;
    public TextMeshProUGUI ClassScore;


    // Start is called before the first frame update
    void Start()
    {

        CityScore.text = "Last score: "+PlayerPrefs.GetInt("CityScore").ToString();
        RestoScore.text = "Last score: "+PlayerPrefs.GetInt("RestoScore").ToString();
        ClassScore.text = "Last score: "+PlayerPrefs.GetInt("ClassScore").ToString();
        
    }

    
}
