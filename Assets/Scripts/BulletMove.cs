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
    {   // *** �ܿ�� ***
        // 1. ���ӿ�����Ʈ���� ã�´�. �÷��̾��� �̸��� ã�Ƽ� Player���� �־���.
       Player = GameObject.Find("Player");
        // 2. (�÷��̾�:�̸�)�� ������Ʈ �߿��� playerfire��� ��ũ��Ʈ�� �����ͼ� pFire�� �־���.
       pFire = Player.GetComponent<PlayerFire>();

        // 

    }

    // Update is called once per frame
    void Update()
    {

        // ������ ���� �������� �̵��ϰ� �ʹ�. 

        //Vector3.up
        Vector3 direction = new Vector3(0, 1, 0);

        // transform.Translate(Vector3.up * moveSpeed * Time.deltaTime); �����Ϸ��� �⺻ ����(:����, �Ʒ�)�� �ʿ���
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
            // �� �Ѿ��� ��Ȱ��ȭ �Ѵ�. 

            
                //Destroy(gameObject);

             // ��Ȱ��ȭ�� �Ѿ��� źâ ����Ʈ�� �߰��Ѵ�.
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

            //    // �ε��� ����� ������ �����Ѵ�.
            //    Destroy(collision.gameObject);

            //}

            //}
        
    }

}
