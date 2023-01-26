using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



public class CanvaRestorant : MonoBehaviour
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

    int randomTrueAnswers=0;
    int randomFalseAnswers1=0;
    int randomFalseAnswers2=0;

                
            

    List<string> questions = new List<string>(){
        "ともこさんこんにちは、。おいしい料理が食べられるレストランに来たんだ。",
        " 私は寿司を食べるつもりだ。ともこさんは？",
        "カレーライスは美味しいよ。でも、私は寿司が好きだから、寿司を食べることにした。",
        "あ、注文しよう。",
        "お店の人に注文するね。",
        "カレーライス好きなの?",
        "なるほどね、寿司注文したけどカレーライス注文したほうがいいかな",
        "やっぱり、このレストランは美味しい料理が食べられるね。",
        "うん、また来よう、じゃあ、行こうか?",
        "じゃあ、またね。"
       
        
    };

    List<string> answers1 = new List<string>(){
        "さっき電話した人は誰ですか？",//
        "おはようございます、今日はいい天気ですね。",
        "こんにちは、お元気ですか？",//
        "あなたの誕生日はいつですか？",
        "あなたは何をしていますか？",
        "今日の新聞は見ましたか？",
        "あなたは何時に帰りますか？",
        "どこに行きたいですか？",//
        "あなたは何をして過ごしますか？",
        "どんな音楽が好きですか？"


    };

    List<string> answers2 = new List<string>(){
        "今日はどこに行きますか？",//
        "あの、すみません、手帳を見せていただけますか？",
        "今日の夕食は何を食べますか？",//
        "今日の天気はどうですか？",
        "今日は休みですか？",
        "これは誰のですか？",
        "あなたはどこから来ましたか？",
        "あなたは好きなスポーツは何ですか？",//
        "あなたは何を勉強していますか？",
        "今日は何をしますか？"
    };

    List<string> answersList= new List<string>(){
        "うん、美味しそうだね。何を食べる？",
        "私はカレーライスを食べるつもりだ。",
        "うん、私もそう思う。でも、私はカレーライスが好きだから、カレーライスを食べることにした。",
        "うん、そうだね。",
        "うん、行こう。",
        "めっちゃすきだよ",
        "どっちでも美味しいよ。",
        "そうだね。また来ようね。",
        "うん、帰りましょう。",
        "バイバイ。"
    };



    // Start is called before the first frame update
    void Start()
    {
    randomTrueAnswers = Random.Range(1, 4);
    randomFalseAnswers1= Random.Range(1, 4);
    randomFalseAnswers2= Random.Range(1, 4);
    while(randomFalseAnswers1==randomTrueAnswers || randomFalseAnswers2==randomTrueAnswers || randomFalseAnswers1==randomFalseAnswers2){
    randomFalseAnswers1= Random.Range(1, 4);
    randomFalseAnswers2= Random.Range(1, 4);
    }


    // for(int z=0; z<questions.Count;z++){
    //         if (trueAnswers[z]==1){
    //             answersList.Add(answers1[z]);
    //         }
    //         if (trueAnswers[z]==2){
    //             answersList.Add(answers2[z]);
    //         }
    //         if (trueAnswers[z]==3){
    //             answersList.Add(answers3[z]);
    //         }
    //     }
    

        
        questionLenght=questions.Count;

        
        Button btn1 = Button1.GetComponent<Button>();
        Button btn2 = Button2.GetComponent<Button>();
        Button btn3 = Button3.GetComponent<Button>();


        initiateQCM();

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

        if (randomTrueAnswers==answer){
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
        randomTrueAnswers = Random.Range(1, 4);
        randomFalseAnswers1= Random.Range(1, 4);
        randomFalseAnswers2= Random.Range(1, 4);
        while(randomFalseAnswers1==randomTrueAnswers || randomFalseAnswers2==randomTrueAnswers || randomFalseAnswers1==randomFalseAnswers2){
        randomFalseAnswers1= Random.Range(1, 4);
        randomFalseAnswers2= Random.Range(1, 4);
        }
        initiateQCM();
        }         

    }

     void scoreDisplay(){
        Debug.Log("Score Display");
        if(i==questions.Count){
            if (SceneManager.GetActiveScene().buildIndex==1){
                PlayerPrefs.SetInt("CityScore", scoreInt);
            }
            else if (SceneManager.GetActiveScene().buildIndex==2){
                PlayerPrefs.SetInt("ClassScore", scoreInt);

            } 
            else if (SceneManager.GetActiveScene().buildIndex==3){
                PlayerPrefs.SetInt("RestoScore", scoreInt);

            }
            Debug.Log("Load Scence");
            SceneManager.LoadScene(0);
            
        }
        else{

        scoreTotal.text="Final Score :"+scoreInt;

        scoreDesription.text="Question "+(i+1)+  ": "+questions[i] +"\r\n"+"\r\n"+ "Bonne réponse: "+answersList[i];
        i++;
    }
     }

     void initiateQCM(){
         StartCoroutine(TypeText());
        if (randomTrueAnswers==1){
            button1Text.text=answersList[i];
        }
        if (randomTrueAnswers==2){
            button2Text.text=answersList[i];
        }
        if (randomTrueAnswers==3){
            button3Text.text=answersList[i];
        }

        if (randomFalseAnswers1==1){
            button1Text.text=answers1[i];
        }
        if (randomFalseAnswers1==2){
            button2Text.text=answers1[i];
        }
        if (randomFalseAnswers1==3){
            button3Text.text=answers1[i];
        } 
         if (randomFalseAnswers2==1){
            button1Text.text=answers2[i];
        }
        if (randomFalseAnswers2==2){
            button2Text.text=answers2[i];
        }
        if (randomFalseAnswers2==3){
            button3Text.text=answers2[i];
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