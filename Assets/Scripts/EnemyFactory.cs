using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public GameObject Enemy;
    public float delayTime = 0.5f;
    public float currentTime = 0;
    public bool Madeis = false;

    // 일정시간마다 에너미를 생성한다.




    void Start()
    {

    }

    void Update()
    {

        //if (Madeis == false)
        //{
        // 만일, 지정된 시간이 되었으면...
        if (Madeis == false)
        {

                if (delayTime <= currentTime)
                {
                    GameObject go = Instantiate(Enemy, transform.position, Quaternion.identity);
                //GameObject go = Instantiate(Enemy);

                Enemy.SetActive(true);
                Madeis = true;
                    currentTime = 0;
                    //print("적");

                }
                else
                {
                    currentTime += Time.deltaTime;

                // ** 시간을 누적한다!!!!!!!!!!!!!!!!!! 멍청한 나

                }


                Madeis = false;
            

        }

        //}
        // 에너미 오브젝트를 생성한다. 

        // 그렇지않다면...

        // 현재 프레임 시간을 누적시킨다.



        // 무조건 위쪽 방향으로 이동하고 싶다. 

        //Vector3.up
        //Vector3 direction = new Vector3(0, -1, 0);

        // transform.Translate(Vector3.up * moveSpeed * Time.deltaTime); 응용하려면 기본 공식(:원리, 아래)이 필요함
        //transform.position += direction * moveSpeed * Time.deltaTime;

        }    
    }
    


