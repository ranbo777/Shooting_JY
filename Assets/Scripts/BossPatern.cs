using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatern : MonoBehaviour
{

    public GameObject missleFactory;
    public Transform[] firePosition = new Transform[2];
    public Transform basePosition;
    public float delayTime = 0.2f;
    

    float currentTime = 0;
    bool startFire = true;

    int fireCount = 0;

    enum BossState
    {
        EMERGE,
        Pattern1,
        Pattern2


    }

    BossState bState = BossState.EMERGE;

    // Start is called before the first frame update
    void Start()
    {
        // ������ ���� ã�´�. 
        basePosition = GameObject.Find("BossBasePoint").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        switch(bState)
        {
            case BossState.EMERGE:
                BossEmergePreocess();
                break;

            case BossState.Pattern1:
                startPattern1();
                break;

            case BossState.Pattern2:
                StartPattern2();
                break;
        }

    }


    void BossEmergePreocess() 
    {
        // ���� ������������ �Ÿ��� 0.05���� �̳���� �������� ���� ��ġ��Ų��.
        if (Vector3.Distance(transform.position, basePosition.position) < 0.05f)
        {
            transform.position = basePosition.position;
            bState = BossState.Pattern1; // ������ ���� 1 ���·� �ٲٰڴ�.

        }
        // �׷��� �ʴٸ�, �Ʒ��� ���� �ӵ��� ��������. 
        else
        {
            transform.position += Vector3.down * 4.0f * Time.deltaTime;
        }
    }

    void StartPattern1()
    {
        if(startFire)
        {
            InvokeRepeating("FireType1", 0, delayTime);
            startFire = false;

        }


    }



    
    if(currentTime <= 2.0f>)
       {
        private void OnBeforeTransformParentChanged()
    {
        firePosition = BossPatern1 
    }
}


    void FireType1() 
    {
        for(int i = 0; i < firePosition.Length; i++)
        {
            Instantiate(missleFactory, firePosition[i].position, Quaternion.Euler(new Vector3(0, 0, 180.0f)));

        }
    
    }


    void Pattern1()
    { 
    
    if(startFire)
            InvokeRepeating
    }

    void Pattern2()
    { 
        if(startFire)
        {
            currentTime = 0;
            startFire = False;

        }

        Pattern2();
    
    }
    void StartPattern2()
    {
        if (startFire)
        {
            currentTime = 0;
            startFire = False;

        }

        Pattern2();

    }
}
