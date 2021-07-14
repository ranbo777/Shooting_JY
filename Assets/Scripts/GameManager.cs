using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float currentTime = 1;

    public static GameManager gm;
 
    public GameObject DeadPanel;
    public GameObject Player;
   public GameObject UI;

   // public GameObject ui;
    public Image backImage;
    public Text resultTxt;
    public Text[] scoreTxt = new Text[2];

    public Color backColor;
    public Color fontColor;
    int fontSize;

    bool fadeStart = false;

    int curScore = 0;
    int BestScore = 0;



    public string Title = "YouDied";

    private void Awake()
    {
        if (gm == null)
        {
            gm = this;

        }
        else
        {
            Destroy(gameObject);

        }

    }


    // Start is called before the first frame update
    void Start()
    {

        backColor = backImage.color;
        fontColor = resultTxt.color;
        fontSize = resultTxt.fontSize;
        // 1. 죽었을때 이벤트 뜬다.

        // 2. 글씨 YouDied 표기.
        // 3. 빨간색, 점점 커짐, 
        // 4. 배경 어두워짐
        UI.SetActive(false);
        scoreTxt[0].text = "현재점수 : 0";

        BestScore = PlayerPrefs.GetInt("HighScore");
        string bestPlayer = PlayerPrefs.GetString("BestString");
        scoreTxt[1].text = "최고 점수 : " + BestScore.ToString() + "-" + bestPlayer;
    }


    
       public void SetActiveUI(bool toggle) 
    {
        UI.SetActive(toggle);
        resultTxt.text = "게임 오버";
        //startFade = toggle;

        // 만일, 현재 점수가 종전에 기록되어 있던 최고 점수를 초과하였다면...
        if(curScore > BestScore)
        { 
        BestScore = curScore;
        // 최고 점수를 현재 점수의 값으로 덮어쓴다(외부 저장장치).
        PlayerPrefs.SetInt("HighScore", BestScore) ;

        }



    }
        
        // YouDied = new string("");
    

    // Update is called once per frame
    void Update()
    {
        if(fadeStart)
        {
            FadeInEffect();
        }


    }
   
        private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);

    }

    //public void SetActiveUI(bool toggle)
    //{
    //    UI.SetActive(toggle);
       
    //}

    void FadeInEffect()
    {

        #region // Lerp 알파값 변경
        currentTime += Time.deltaTime;

        // 뒷 배경판의 알파값을 변경하기.
        float backAlpha = Mathf.Lerp(backColor.a, 0.7f, currentTime);
        backImage.color = new Color(backImage.color.r, backImage.color.g, backImage.color.b, backAlpha);

        // 폰트의 색상 알파 값을 변경하기.
        float fontAlpha = Mathf.Lerp(fontColor.a, 1.0f, currentTime);
        resultTxt.color = fontColor + new Color(0, 0, 0, fontAlpha);
        // 그만큼의 변화량으로 Add 하겠다. 

        // 폰트의 크기를 변경하기
        int fontDelta = (int)Mathf.Lerp(fontSize, 90, currentTime);
        resultTxt.fontSize = fontDelta;

        //**float를 int로 변화하는 방법 ? (int)
        // 색깔이나 사이즈를 시간이 지날수로 변화하도록 하는 공식!!!!!!!!!!!!!!!!
        
        #endregion
    }



    public void AddPoint(int point)
    {

        // 현재 점수가 point만큼 추가된다.
        curScore += point;

        scoreTxt[0].text = "현재 점수: " + curScore.ToString();

        // 만일, 현재 0

    }

    //최고 점수 갱신 여부에 따라 재시작 방식을 달리하기, 
    public void CheckScoreResult() 
    {

        // 만일, 현재 스코어가 최고 점수를 초과하였다면.

        if (curScore > BestScore)
        {
           // 스코어 패널을 활성화한다.

        }
        // 그렇지않다면.
        else
        {
            SceneManager.LoadScene("ShootingScene");
            Time.timeScale = 1.0f;

        }



    }

}
