using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{

    public GameObject bulletFactory;
    // �迭�� ���� public Transform firePosition[5];

    public Transform firePosition;
    public Transform firePosition1;
    public Transform firePosition2;
    public Transform firePosition3;
    public Transform firePosition4;
    public GameObject wareHouse;

    GameObject go;
    // 06.30 �ָӴϿ� ���� bullets�� źâ�� 20����!
    public List <GameObject> magazine = new List<GameObject>();

    // public GameObject[] magazine = new GameObject[20];
    // �迭��.


    //1���� 5���� ����� �־�.. ī��Ʈ ������ ���� �Ѿ� �߻� ��ư�� ���缭 �Ѿ��̿�. 

    [Range(1, 5)] public int bulletCount = 0;
    public int range = 1;
    // range = �Ѿ� ���� (interval)
    

    void Start()
    {
        
        magazine.Clear();

        // 06.30 źâ �ָӴ�(�迭)�� 20(bullets.Length) ���� ���� �ִ´�!
        for (int i = 0; i < 20; i++)
        {

            GameObject go = Instantiate(bulletFactory);
            magazine.Add(go); 

            //magazine[i] = Instantiate(bulletFactory);

            // ������ �Ѿ��� �÷��̾� �ڽ����� �������!
            go.transform.parent = wareHouse.transform;
            //magazine[i].transform.parent = transform; //(Ʈ������ = �� ��ġ? = �پ��ִ� ��ġ = Player )
            // = magazine[i].transform.Setparents(transform);

            // ������ �Ѿ��� ��Ȱ��ȭ�Ѵ�.

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

            // Mathf.Max (a, b) a~b �߿��� ������ �ִ�.

        }

       

        // ����, ���콺 ���� ��ư�� Ŭ���ϸ�, 
        if (Input.GetButtonDown("Fire1"))
        {
            FireStyle2();
            // ����, źâ�� �Ѿ��� �ִٸ�...
           
            #region źâ �迭�ϰ��
            //for (int i = 0; i < 20; i++)
            //{
            //    if (magazine[i].activeInHierarchy == false)
            //    // = !magazine[i].activeInHierarchy
            //    {
            //        // źâ�� ��Ȱ��ȭ �Ǿ��ִ� �Ѿ��� Ȱ��ȭ�Ѵ�.
            //        magazine[i].SetActive(true);

            //        break;

            //    }

            //} �迭�� ���� ���

            //RangeAttribute range = new RangeAttribute(1, 5) ;

            //range = floatrange;

            #endregion 



           // if (bulletFactory != null)
           // {

               // FireStyle2();

                #region �Ѿ˾ȳ�~~ 
                //�Ѿ��� �����Ѵ�. 
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
    //    // �� ���� ����, ���� ���� ���.
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
        // ���̰��� ����, �� ���� ���.
        // �Ѿ� ���� ������ �Ѿ��� ������ ������� ���������� ���ڳ�...
        // 
        //print("���Գ�?");
        // 1. �� ������ ����Ѵ�
        float distance = range * (bulletCount - 1);

        // 2. ���� �Ǻ��� �������� ��´�.
        Vector3 anchor = transform.position + new Vector3(distance * -0.5f, 1.2f, 0);

        // 3. �Ǻ����κ��� �Ѿ� ���ݸ�ŭ �����ϰ� �Ѿ��� �����Ѵ�.
        for (int i = 0; i < bulletCount; i++)
        {
            //print("���Գ�?");
            if (magazine.Count > 0)
            {
               // go.transform.position = anchor + new Vector3(range * i, 0, 0);
               //  go.transform.position = magazine[0].transform.position

                // źâ�� ù ��° �Ѿ��� Ȱ��ȭ��Ų��. 
                magazine[0].SetActive(true);
                // Ȱ��ȭ�� �Ѿ��� �ѱ��� ��ġ��Ų��. a = b  (a �� b�� ���Խ�Ų��)   
                magazine[0].transform.position = anchor + new Vector3(range * i, 0, 0);
                // firePosition.position;
                // Ȱ��ȭ �� �Ѿ��� źâ���� ����(�ָӴϿ��� ������ ������Ʈ�� ���´�)�Ѵ�. - �պκ� ���� �����ذ���.
                magazine.RemoveAt(0); // -> Index���� ã�Ƽ� ����

                // magazine.Remove(0); -> Object�� ���� ����
            }
            // GameObject go = Instantiate(bulletFactory);
            // go.transform.position = anchor + new Vector3(range * i, 0, 0);
        }

    }

}



