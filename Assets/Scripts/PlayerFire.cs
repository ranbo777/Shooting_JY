using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{

    public GameObject bulletFactory;
    // 배열로 돌려 public Transform firePosition[5];

    public Transform firePosition;
    public Transform firePosition1;
    public Transform firePosition2;
    public Transform firePosition3;
    public Transform firePosition4;
    public GameObject wareHouse;

    GameObject go;
    // 06.30 주머니에 넣을 bullets의 탄창은 20개다!
    public List <GameObject> magazine = new List<GameObject>();

    // public GameObject[] magazine = new GameObject[20];
    // 배열임.


    //1에서 5까지 맞출수 있어.. 카운트 갯수에 따라서 총알 발사 버튼을 맞춰서 총알이요. 

    [Range(1, 5)] public int bulletCount = 0;
    public int range = 1;
    // range = 총알 간격 (interval)
    

    void Start()
    {
        
        magazine.Clear();

        // 06.30 탄창 주머니(배열)에 20(bullets.Length) 개를 집어 넣는다!
        for (int i = 0; i < 20; i++)
        {

            GameObject go = Instantiate(bulletFactory);
            magazine.Add(go); 

            //magazine[i] = Instantiate(bulletFactory);

            // 생생된 총알을 플레이어 자식으로 등록하자!
            go.transform.parent = wareHouse.transform;
            //magazine[i].transform.parent = transform; //(트랜스폼 = 내 위치? = 붙어있는 위치 = Player )
            // = magazine[i].transform.Setparents(transform);

            // 생성된 총알을 비활성화한다.

            // magazine[i].SetActive(false);
            go.SetActive(false);


        }

    }

    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Q))
        {
            bulletCount = Mathf.Min(bulletCount - 1, 1);

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            bulletCount = Mathf.Max(bulletCount + 1, 5);

            // Mathf.Max (a, b) a~b 중에서 작은게 최댓값.

        }

       

        // 만일, 마우스 좌측 버튼을 클릭하면, 
        if (Input.GetButtonDown("Fire1"))
        {
            FireStyle2();
            // 만일, 탄창에 총알이 있다면...
           
            #region 탄창 배열일경우
            //for (int i = 0; i < 20; i++)
            //{
            //    if (magazine[i].activeInHierarchy == false)
            //    // = !magazine[i].activeInHierarchy
            //    {
            //        // 탄창에 비활성화 되어있는 총알을 활성화한다.
            //        magazine[i].SetActive(true);

            //        break;

            //    }

            //} 배열로 만든 경우

            //RangeAttribute range = new RangeAttribute(1, 5) ;

            //range = floatrange;

            #endregion 



           // if (bulletFactory != null)
           // {

               // FireStyle2();

                #region 총알안녕~~ 
                //총알을 생성한다. 
                //go.transform.position = transform.position + Vector3.up * 2;




                //    go = Instantiate(bulletFactory);
                //    go.transform.position = firePosition.position;
                //    print("1");



                //if (range == 2)
                //{

                //    go.transform.position = firePosition1.position;
                //    go = Instantiate(bulletFactory);
                //    return;
                //}


                //if (range == 3)
                //{


                //    go = Instantiate(bulletFactory);
                //    go.transform.position = firePosition1.position;
                //    go = Instantiate(bulletFactory);
                //    go.transform.position = firePosition2.position;
                //    return;
                //}


                //if (range == 4)
                //{

                //    go = Instantiate(bulletFactory);
                //    go.transform.position = firePosition1.position;
                //    go = Instantiate(bulletFactory);
                //    go.transform.position = firePosition2.position;
                //    go = Instantiate(bulletFactory);
                //    go.transform.position = firePosition3.position;
                //    go = Instantiate(bulletFactory);
                //    return;
                //}



                //if (range == 5)
                //{

                //    go = Instantiate(bulletFactory);
                //    go.transform.position = firePosition1.position;
                //    go = Instantiate(bulletFactory);
                //    go.transform.position = firePosition2.position;
                //    go = Instantiate(bulletFactory);
                //    go.transform.position = firePosition3.position;
                //    go = Instantiate(bulletFactory);
                //    go.transform.position = firePosition4.position;

                //    print("D");

                //    return;
                //}


                //      if (range == 5)
                //     {
                //     go = Instantiate(bulletFactory);
                //     go.transform.position = firePosition4.position;

                //                    print("D");


                //                  return;
                //            }

                #endregion
           // }
        }
    }



    //void firestyle1() 

    //{
    //    // 총 간격 고정, 사이 간격 계산.
    //    for (int i = 0; i < bulletcount; i++)
    //    {
    //        vector3 anchor = transform.position + new vector3(range * -0.5f, 1.2f, 0);

    //        gameobject go = instantiate(bulletfactory);

    //        float term = range / (float)(bulletcount + 1);

    //        go.transform.position = anchor + new vector3(term * (i + 1), 0, 0);

    //    }
    //}

    void FireStyle2()
    {
        // 사이간격 고정, 총 간격 계산.
        // 총알 간의 간격이 총알의 갯수에 상관없이 일정했으면 좋겠네...
        // 
        //print("나왔냐?");
        // 1. 총 간격을 계산한다
        float distance = range * (bulletCount - 1);

        // 2. 좌측 피봇의 기준점을 잡는다.
        Vector3 anchor = transform.position + new Vector3(distance * -0.5f, 1.2f, 0);

        // 3. 피봇으로부터 총알 간격만큼 일정하게 총알을 생성한다.
        for (int i = 0; i < bulletCount; i++)
        {
            //print("나왔냐?");
            if (magazine.Count > 0)
            {
               // go.transform.position = anchor + new Vector3(range * i, 0, 0);
               //  go.transform.position = magazine[0].transform.position

                // 탄창의 첫 번째 총알을 활성화시킨다. 
                magazine[0].SetActive(true);
                // 활성화된 총알을 총구에 위치시킨다. a = b  (a 에 b를 대입시킨다)   
                magazine[0].transform.position = anchor + new Vector3(range * i, 0, 0);
                // firePosition.position;
                // 활성화 된 총알을 탄창에서 제거(주머니에서 독립된 오브젝트로 끊는다)한다. - 앞부분 부터 삭제해간다.
                magazine.RemoveAt(0); // -> Index에서 찾아서 지워

                // magazine.Remove(0); -> Object를 직접 지워
            }
            // GameObject go = Instantiate(bulletFactory);
            // go.transform.position = anchor + new Vector3(range * i, 0, 0);
        }

    }

}



