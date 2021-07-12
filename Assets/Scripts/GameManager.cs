using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Color backColor;
    public Color fontColor;
    int fontSize;

    bool fadeStart = false;



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

    public void SetActiveUI(bool toggle)
    {
        UI.SetActive(toggle);
       
    }

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
}
