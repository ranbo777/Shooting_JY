using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    // 사용자의 상하좌우 키를 입력하여, 오브젝트를 움직이고 싶다.
    // 입력 방식 : 화살표 키의 상하좌우 또는 WASD 키를 이용한 상하좌우 플레이어의 이동 구현! 
    // 필요 요소 : 속도(벡터) = (방향 + 속력(스칼라) )

   public GameObject player;

    public Transform P_Transform;
    public float moveSpeed = 0.1f;
    public Vector3 subdivide;
    Rigidbody rb;
    float dashSpeed = 0.1f;

    void Start()
    {
        ViewportClamp();
    }


    void Update()
    {


        // 1. W입력시 프린트
        // if (Input.GetKeyDown(KeyCode.W))
        // {
        //     print("난 니가 W 키를 누른 사실을 알고있다..");
        // }

        // 2. Axis (Project에 있는 정의된 키값? Vertical)
        //float value = Input.GetAxis("Vertical");
        //print(value);

        // 3. Raw(날것) GetAxis 사용자의 상하 좌우 입력 값을 받아온다.
        // 
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

       

        // 받은 입력값을 방향 값으로 만들고 싶다.
        Vector3 direction = new Vector3(h, v, 0);

        
        direction.Normalize();

        // 그 방향으로 이동을 하겠다!
        // F (힘) = m(질량)a(가속도)
        // a (가속도) = f/m 
        // p = p0 + v(direction * moveSpeed) t (1) 
        // transform.position = transform.position + direction * moveSpeed * 1;(아래와같다)
        
        // transform.position += direction * moveSpeed * 1; (시간 정규 보간) lerp 
        
        // print(Time.deltaTime);
        // 만일, 좌측 쉬프트를 누르면...


        if (Input.GetKey(KeyCode.LeftShift))
        {
        //스피드 변수의 값을 2배로 증가시킨다.
            direction += direction * 3 ;
         //   print("D");
        
        // 그렇지 않고, 좌측 쉬프트 버튼을 떼면...
        //moveSpeed 변수의 값을 원래대로 한다.

        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            dashSpeed = moveSpeed;

        }

        transform.position += direction * moveSpeed * Time.deltaTime;

        // 1. 플레이어의 위치를 뷰포트 좌표로 변환한다.
        // (월드 좌표를 뷰포트값으로 바꿔줌)


        //print(playerViewPos);
        // 2. 변환된 뷰포트 좌표의 값이 0 - 1 사이를 벗어나지 못하도록 한다. 
        rb.velocity = direction * dashSpeed;


        //(Clamp 0~1 = Clamp 01)
        player = GameObject.Find("Player");

        P_Transform = player.GetComponent<Transform>();

        Vector3 Minus;
        Vector3 Plus;
        Minus = new Vector3 ((P_Transform.position.x - (P_Transform.localScale.x * 0.5f)), 0, 0);
        Plus = new Vector3 ((P_Transform.position.x + (P_Transform.localScale.x * 0.5f)), 0, 0);

        //transform.position - new Vector3(Mathf.Clamp(1f, (P_Transform.position.x - (P_Transform.localScale.x * 0.5f)), 1f - (P_Transform.position.x + (P_Transform.localScale.x * 0.5f))), 0, 0)

        //int PowerX = player.transform.position ;


        print(subdivide);
       // float vx;
       // float vy;


       // Vector3 hello = new Vector3(vx, vy, 0);


        
        // float posX = playerViewPos.x -


     

    }

    bool D()
    {
        return Input.GetButton("Fire1");    
    }


    private void ViewportClamp() 
    
    {
        Vector3 playerViewPos = Camera.main.WorldToViewportPoint(transform.position);

        playerViewPos.x = Mathf.Clamp01(playerViewPos.x);
        playerViewPos.y = Mathf.Clamp01(playerViewPos.y);

        // 3. 계산된 뷰포트 값을 플레이어의 위치 값으로 적용한다. 뷰포트를 월드 좌표로 다시 재환산한다. 
        Vector3 playerWorldPos = Camera.main.ViewportToWorldPoint(playerViewPos);


    }
}



// 1. 게임오브젝트에서 찾는다. 플레이어라는 이름을 찾아서 Player에다 넣었다.
 //Player = GameObject.Find("Player");
// 2. (플레이어:이름)의 컴포넌트 중에서 playerfire라는 스크립트를 가져와서 pFire에 넣었다.
        //  pFire = Player.GetComponent<PlayerFire>();