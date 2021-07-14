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
        // 1. �׾����� �̺�Ʈ ���.

        // 2. �۾� YouDied ǥ��.
        // 3. ������, ���� Ŀ��, 
        // 4. ��� ��ο���
        UI.SetActive(false);
        scoreTxt[0].text = "�������� : 0";

        BestScore = PlayerPrefs.GetInt("HighScore");
        string bestPlayer = PlayerPrefs.GetString("BestString");
        scoreTxt[1].text = "�ְ� ���� : " + BestScore.ToString() + "-" + bestPlayer;
    }


    
       public void SetActiveUI(bool toggle) 
    {
        UI.SetActive(toggle);
        resultTxt.text = "���� ����";
        //startFade = toggle;

        // ����, ���� ������ ������ ��ϵǾ� �ִ� �ְ� ������ �ʰ��Ͽ��ٸ�...
        if(curScore > BestScore)
        { 
        BestScore = curScore;
        // �ְ� ������ ���� ������ ������ �����(�ܺ� ������ġ).
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

        #region // Lerp ���İ� ����
        currentTime += Time.deltaTime;

        // �� ������� ���İ��� �����ϱ�.
        float backAlpha = Mathf.Lerp(backColor.a, 0.7f, currentTime);
        backImage.color = new Color(backImage.color.r, backImage.color.g, backImage.color.b, backAlpha);

        // ��Ʈ�� ���� ���� ���� �����ϱ�.
        float fontAlpha = Mathf.Lerp(fontColor.a, 1.0f, currentTime);
        resultTxt.color = fontColor + new Color(0, 0, 0, fontAlpha);
        // �׸�ŭ�� ��ȭ������ Add �ϰڴ�. 

        // ��Ʈ�� ũ�⸦ �����ϱ�
        int fontDelta = (int)Mathf.Lerp(fontSize, 90, currentTime);
        resultTxt.fontSize = fontDelta;

        //**float�� int�� ��ȭ�ϴ� ��� ? (int)
        // �����̳� ����� �ð��� �������� ��ȭ�ϵ��� �ϴ� ����!!!!!!!!!!!!!!!!
        
        #endregion
    }



    public void AddPoint(int point)
    {

        // ���� ������ point��ŭ �߰��ȴ�.
        curScore += point;

        scoreTxt[0].text = "���� ����: " + curScore.ToString();

        // ����, ���� 0

    }

    //�ְ� ���� ���� ���ο� ���� ����� ����� �޸��ϱ�, 
    public void CheckScoreResult() 
    {

        // ����, ���� ���ھ �ְ� ������ �ʰ��Ͽ��ٸ�.

        if (curScore > BestScore)
        {
           // ���ھ� �г��� Ȱ��ȭ�Ѵ�.

        }
        // �׷����ʴٸ�.
        else
        {
            SceneManager.LoadScene("ShootingScene");
            Time.timeScale = 1.0f;

        }



    }

}
