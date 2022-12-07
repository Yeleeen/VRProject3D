using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Canva : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI button1Text;
    public Button Button1;
    public TextMeshProUGUI button2Text;
    public Button Button2;
    public TextMeshProUGUI button3Text;
    public Button Button3;


     public TextMeshProUGUI scoreText;

    int i=0;
    int scoreInt=0;


    List<string> questions = new List<string>(){
        "How are you ?",
        "What is your name ?",
    };

    List<string> answers1 = new List<string>(){
        "Good and you ?",
        "Where is the castle ?",
    };

    List<string> answers2 = new List<string>(){
        "I like pizza",
        "Robert",
    };

    List<string> answers3 = new List<string>(){
        "I lost my phone",
        "Happy birthday !",
    };

    List<int> trueAnswers = new List<int>(){
        1,
        2,
    };

    // Start is called before the first frame update
    void Start()
    {
        
        Button btn1 = Button1.GetComponent<Button>();
        Button btn2 = Button2.GetComponent<Button>();
        Button btn3 = Button3.GetComponent<Button>();
		

        StartCoroutine(TypeText());
        button1Text.text=answers1[i];
        button2Text.text=answers2[i];
        button3Text.text=answers3[i];

        scoreText.text=""+scoreInt;


        Button1.onClick.AddListener(delegate{ChangeQuestion( 1);});
        Button2.onClick.AddListener(delegate{ChangeQuestion( 2);});
        Button3.onClick.AddListener(delegate{ChangeQuestion( 3);});
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void changeText(){
        button1Text.text="222";
    }
    void TaskOnClick(){
		Debug.Log ("You have clicked the button!");
	}

    void ChangeQuestion(int answer){
        i=i+1;

        if (trueAnswers[i-1]==answer){
            scoreInt++;
            scoreText.text=""+scoreInt;
        }

        if (i==questions.Count){

            scoreText.text="Fini ! Score :"+scoreInt;
        }
        else
        {
            StartCoroutine(TypeText());
        button1Text.text=answers1[i];
        button2Text.text=answers2[i];
        button3Text.text=answers3[i];
            
        }


        

        

    }

    IEnumerator TypeText(){

        questionText.text=string.Empty;

        for (int y=0; y<questions[i].Length; y++){
            questionText.text+=questions[i][y];
            yield return new WaitForSeconds(0.05f);
            
        }
        yield return null;
    }
}
