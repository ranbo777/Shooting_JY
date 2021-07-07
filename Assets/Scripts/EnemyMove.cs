using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    float moveSpeed = 10.0f;
    public GameObject Player;
    public int FollowP = 10; 
    public Vector3 go;
    public bool ischecked = true;
    public int[] checkedRandom = new int[2];


    Animation myAnim;

    // Start is called before the first frame update
    void Start()
    {  //  랜덤 독립 실행 확률 검증 테스트  
        //CheckResult();
        int follow = Random.Range(0, 10);

        //애니메이션 자식의 오브젝트 콤포넌트를 가져옴. 
        myAnim = GetComponentInChildren<Animation>();
        myAnim.Play();

        //print(follow);
        //ischecked = true;

        if (follow <= FollowP)//&& ischecked == true)
        {

            Player = GameObject.Find("Player");
            if(Player != null)
            {
                go = Player.transform.position - transform.position;
            // 나를 쫓아오렴

            //Vector3 direction = go;

            // 정규화
            go.Normalize();
                //ischecked = false;
            }
            else
            {

                go = Vector3.down;
                go.Normalize();
            }
        }
     

        else
        {
            // Vector3 direction = new Vector3(0, -1, 0);

            go = Vector3.down;
            go.Normalize();
        }
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += go * moveSpeed * Time.deltaTime;
    }


    private void OnCollisionEnter(Collision collision)
    {
        // print(((byte)collision.gameObject.layer));
        // float go = (byte)collision.gameObject.layer; 

        // print(go);

        if(collision.gameObject.layer == LayerMask.NameToLayer("Player")) 
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    void CheckResult()
    
    {

        // 누적시킨다 ! 100000 단독 실행 :
        // for 문으로 반복 실행, 퍼센트 수렴의 체크 . 
        for (int i = 0; i < 100000; i++) 
        {

            int result = Random.Range(1, 101);


            if (result <= 70)
            {
                checkedRandom[0]++;
            }

            else 
            {
                checkedRandom[1]++;
            }
        
        
        }
    
    }

}
