using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public GameObject Enemy;
    public float delayTime = 0.5f;
    public float currentTime = 0;
    public bool Madeis = false;

    // �����ð����� ���ʹ̸� �����Ѵ�.




    void Start()
    {

    }

    void Update()
    {

        //if (Madeis == false)
        //{
        // ����, ������ �ð��� �Ǿ�����...
        if (Madeis == false)
        {

                if (delayTime <= currentTime)
                {
                    GameObject go = Instantiate(Enemy, transform.position, Quaternion.identity);
                //GameObject go = Instantiate(Enemy);

                Enemy.SetActive(true);
                Madeis = true;
                    currentTime = 0;
                    //print("��");

                }
                else
                {
                    currentTime += Time.deltaTime;

                // ** �ð��� �����Ѵ�!!!!!!!!!!!!!!!!!! ��û�� ��

                }


                Madeis = false;
            

        }

        //}
        // ���ʹ� ������Ʈ�� �����Ѵ�. 

        // �׷����ʴٸ�...

        // ���� ������ �ð��� ������Ų��.



        // ������ ���� �������� �̵��ϰ� �ʹ�. 

        //Vector3.up
        //Vector3 direction = new Vector3(0, -1, 0);

        // transform.Translate(Vector3.up * moveSpeed * Time.deltaTime); �����Ϸ��� �⺻ ����(:����, �Ʒ�)�� �ʿ���
        //transform.position += direction * moveSpeed * Time.deltaTime;

        }    
    }
    


