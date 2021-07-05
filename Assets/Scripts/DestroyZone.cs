using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{

    // playerFire Ŭ������ ��� ������ pFire�̴�.
    public PlayerFire pFire;
    // ****�ٸ� Ŭ������ �ִ� ������ �������� ���� �� ����Ѵ�!! �����߿� ****

    // ������ �ε��� ����� �����Ѵ�. 
    // �ʿ� ��� : �ð�, ���ʹ� ������Ʈ ����, ���� ��ġ
    

    void Start()
    {
       
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �ε��� ����� �̸��� Bullet�̶�� ���ڸ� �����ϰ� �ִٸ�...
        if (collision.gameObject.name.Contains("Bullet"))
        // (collision.gameObject.name == "Bullet(Clone)") 
        {

            // �� �Ѿ��� ��Ȱ��ȭ �Ѵ�. 
            collision.gameObject.SetActive(false);

            // ��Ȱ��ȭ�� �Ѿ��� źâ ����Ʈ�� �߰��Ѵ�.
            pFire.magazine.Add(collision.gameObject);
        }
        else
        {

            // �ε��� ����� ������ �����Ѵ�.
            Destroy(collision.gameObject);

        }


    }



}
