using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// ** UI에 있는거 가져올때 꼭 쓰세요..

public class Lerp : MonoBehaviour
{
    public static Lerp lp;
    public float ColorResult = 0;
    public float TextSizeresult = 80;

    public float targetTime = 3 ;
    public float currentTime = 0;

    public float Alpha = 0;

   // public GameObject UI;
    public Color BackColors;
    public Image backImage;
    public Text resultTxt;

    // float currenTime = 0;

    // Vector3 startPos;

    bool fadeStart2 = false;
    public float text;

    // Start is called before the first frame update
    void Start()
    {
        
    backImage = backImage.GetComponent<Image>();
    // 1. 원하는 이미지를 가져옴.
    resultTxt = resultTxt.GetComponent<Text>();
    // 2. 원하는 이미지의 텍스트를 가져옴.
    BackColors = backImage.color;
    // 3. 이미지의 컬러를 가져옴.

    }

    // Update is called once per frame
    void Update()
    {
        // result 변수의 값을 1초 동안 10까지 변화하도록 한다. 
        FadeEffect();

    }

    public void FadeEffect()
    {

        currentTime += Time.deltaTime * 0.01f;
        ColorResult = Mathf.Lerp(backImage.color.a, 1f, currentTime);
        print(ColorResult);


        backImage.color = new Color(backImage.color.r, backImage.color.g, backImage.color.b, ColorResult);
        //Alpha = result;

        // transform.position = startPos + new Vector3(result, 0, 0);

        //new Color(0, 0, 0, 0);

    }
}
