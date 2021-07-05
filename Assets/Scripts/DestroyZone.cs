using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{

    // playerFire 클래스를 담는 변수는 pFire이다.
    public PlayerFire pFire;
    // ****다른 클래스에 있는 변수를 가져오고 싶을 때 사용한다!! 아주중요 ****

    // 나에게 부딪힌 대상을 제거한다. 
    // 필요 요소 : 시간, 에너미 오브젝트 원본, 생성 위치
    

    void Start()
    {
       
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 부딪힌 대상의 이름이 Bullet이라는 글자를 포함하고 있다면...
        if (collision.gameObject.name.Contains("Bullet"))
        // (collision.gameObject.name == "Bullet(Clone)") 
        {

            // 그 총알을 비활성화 한다. 
            collision.gameObject.SetActive(false);

            // 비활성화된 총알을 탄창 리스트에 추가한다.
            pFire.magazine.Add(collision.gameObject);
        }
        else
        {

            // 부딪힌 대상을 씬에서 제거한다.
            Destroy(collision.gameObject);

        }


    }



}
