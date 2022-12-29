using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



public class Canva : MonoBehaviour
{

    public GameObject questionCanva;
    public GameObject pauseMenuCanva;
    public GameObject scoreCanva;
    
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI button1Text;
    public Button Button1;
    public TextMeshProUGUI button2Text;
    public Button Button2;
    public TextMeshProUGUI button3Text;
    public Button Button3;


     public TextMeshProUGUI scoreText;

     public TextMeshProUGUI scoreTotal;
     public TextMeshProUGUI scoreDesription;
     public Button next;

    int i=0;
    int scoreInt=0;
    int questionLenght=0;


    List<string> questions = new List<string>(){
        "How are you ?",
        "What is your name ?",
    };

    List<string> answers1 = new List<string>(){
        "Good and you ?",
        "Where is the castle ?",
    };

    List<string> answers2 = new List<string>(){
        "I like pizza.",
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
    List<string> answersList = new List<string>(){};

    // Start is called before the first frame update
    void Start()
    {

        for(int z=0; z<questions.Count;z++){
            if (trueAnswers[z]==1){
                answersList.Add(answers1[z]);
            }
            if (trueAnswers[z]==2){
                answersList.Add(answers2[z]);
            }
            if (trueAnswers[z]==3){
                answersList.Add(answers3[z]);
            }
        }
        questionLenght=questions.Count;

        
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

        next.onClick.AddListener(delegate{scoreDisplay();});
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }


   

    void ChangeQuestion(int answer){
        Debug.Log("ChangeQuestion");
        i=i+1;

        if (trueAnswers[i-1]==answer){
            scoreInt++;
            scoreText.text=""+scoreInt;
        }

        if (i==questions.Count){
        i=0;
        questionCanva.SetActive(false);
        pauseMenuCanva.SetActive(false);
        scoreDisplay();
        }
        else
        {
            StartCoroutine(TypeText());
        button1Text.text=answers1[i];
        button2Text.text=answers2[i];
        button3Text.text=answers3[i];
            
        }         

    }

     void scoreDisplay(){
        Debug.Log("Score Display");
        if(i==questions.Count){
            Debug.Log("Load Scence");
            SceneManager.LoadScene(1);
            
        }
        else{

        scoreTotal.text="Fini ! Score :"+scoreInt;

        scoreDesription.text="Question "+i+1+  ": "+questions[i] +"\r\n"+"\r\n"+ "Bonne réponse: "+answersList[i];
        i++;
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
