using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove : MonoBehaviour
{

    // ��� �̹����� �Ʒ��� �������� ��ũ�� ��Ű�� �ʹ�.
    // ��ũ�� ����, ��ũ�� �ӷ�, Material�� ��ȭ��Ű���� �ϴ� uv��


    public float scrollSpeed = 1.0f;
     Material backMat;

    // Start is called before the first frame update
    void Start()
    {
        // �޽� ���������� ��Ƽ������ �����´�.
        backMat = GetComponent<MeshRenderer>().material;
        

    }

    // Update is called once per frame
    void Update()
    {

        // ���͸����� uv�����¿��� y�� ���� ������Ų��. // ������Ƽ�� ����(set) �Ͽ���.
        // �޷��ִ� ���� ������Ʈ�� ���͸����� 0��(Main) �ؽ����� �������� ��ũ�ѽ��ǵ常ŭ �ð��� �������� �����Ѵ�.
        backMat.mainTextureOffset += new Vector2(0,-1f) * scrollSpeed * Time.deltaTime;
    }
}
