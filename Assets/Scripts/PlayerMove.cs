using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    // ������� �����¿� Ű�� �Է��Ͽ�, ������Ʈ�� �����̰� �ʹ�.
    // �Է� ��� : ȭ��ǥ Ű�� �����¿� �Ǵ� WASD Ű�� �̿��� �����¿� �÷��̾��� �̵� ����! 
    // �ʿ� ��� : �ӵ�(����) = (���� + �ӷ�(��Į��) )

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


        // 1. W�Է½� ����Ʈ
        // if (Input.GetKeyDown(KeyCode.W))
        // {
        //     print("�� �ϰ� W Ű�� ���� ����� �˰��ִ�..");
        // }

        // 2. Axis (Project�� �ִ� ���ǵ� Ű��? Vertical)
        //float value = Input.GetAxis("Vertical");
        //print(value);

        // 3. Raw(����) GetAxis ������� ���� �¿� �Է� ���� �޾ƿ´�.
        // 
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

       

        // ���� �Է°��� ���� ������ ����� �ʹ�.
        Vector3 direction = new Vector3(h, v, 0);

        
        direction.Normalize();

        // �� �������� �̵��� �ϰڴ�!
        // F (��) = m(����)a(���ӵ�)
        // a (���ӵ�) = f/m 
        // p = p0 + v(direction * moveSpeed) t (1) 
        // transform.position = transform.position + direction * moveSpeed * 1;(�Ʒ��Ͱ���)
        
        // transform.position += direction * moveSpeed * 1; (�ð� ���� ����) lerp 
        
        // print(Time.deltaTime);
        // ����, ���� ����Ʈ�� ������...


        if (Input.GetKey(KeyCode.LeftShift))
        {
        //���ǵ� ������ ���� 2��� ������Ų��.
            direction += direction * 3 ;
         //   print("D");
        
        // �׷��� �ʰ�, ���� ����Ʈ ��ư�� ����...
        //moveSpeed ������ ���� ������� �Ѵ�.

        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            dashSpeed = moveSpeed;

        }

        transform.position += direction * moveSpeed * Time.deltaTime;

        // 1. �÷��̾��� ��ġ�� ����Ʈ ��ǥ�� ��ȯ�Ѵ�.
        // (���� ��ǥ�� ����Ʈ������ �ٲ���)


        //print(playerViewPos);
        // 2. ��ȯ�� ����Ʈ ��ǥ�� ���� 0 - 1 ���̸� ����� ���ϵ��� �Ѵ�. 
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

        // 3. ���� ����Ʈ ���� �÷��̾��� ��ġ ������ �����Ѵ�. ����Ʈ�� ���� ��ǥ�� �ٽ� ��ȯ���Ѵ�. 
        Vector3 playerWorldPos = Camera.main.ViewportToWorldPoint(playerViewPos);


    }
}



// 1. ���ӿ�����Ʈ���� ã�´�. �÷��̾��� �̸��� ã�Ƽ� Player���� �־���.
 //Player = GameObject.Find("Player");
// 2. (�÷��̾�:�̸�)�� ������Ʈ �߿��� playerfire��� ��ũ��Ʈ�� �����ͼ� pFire�� �־���.
        //  pFire = Player.GetComponent<PlayerFire>();