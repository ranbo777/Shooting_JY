using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{

    public float moveSpeed = 10;
    public PlayerFire pFire;
    public GameObject Player;




    // Start is called before the first frame update
    void Start()
    {   // *** 외우기 ***
        // 1. 게임오브젝트에서 찾는다. 플레이어라는 이름을 찾아서 Player에다 넣었다.
       Player = GameObject.Find("Player");
        // 2. (플레이어:이름)의 컴포넌트 중에서 playerfire라는 스크립트를 가져와서 pFire에 넣었다.
       pFire = Player.GetComponent<PlayerFire>();

        // 

    }

    // Update is called once per frame
    void Update()
    {

        // 무조건 위쪽 방향으로 이동하고 싶다. 

        //Vector3.up
        Vector3 direction = new Vector3(0, 1, 0);

        // transform.Translate(Vector3.up * moveSpeed * Time.deltaTime); 응용하려면 기본 공식(:원리, 아래)이 필요함
        transform.position += direction * moveSpeed * Time.deltaTime;

    }

    private void OnCollisionEnter(Collision collision)
    {
        //dead = GameObject.Find("Enemy(Clone)");
        //if (gameObject.name.Contains("Enemy"))
        //{(Player != null)
        
        
            if (collision.gameObject.name.Contains("Enemy") )
            // (collision.gameObject.name == "Bullet(Clone)") 
            {

            Destroy(collision.gameObject);
            //dead.gameObject.SetActive(false);
            // 그 총알을 비활성화 한다. 

            
                //Destroy(gameObject);

             // 비활성화된 총알을 탄창 리스트에 추가한다.
            pFire.magazine.Add(gameObject);

            gameObject.SetActive(false);


        }
            
            else if(Player = null)  
            {
                gameObject.SetActive(false);
                pFire.magazine.Add(collision.gameObject);

              }
            //else
            //{

            //    // 부딪힌 대상을 씬에서 제거한다.
            //    Destroy(collision.gameObject);

            //}

            //}
        
    }

}
