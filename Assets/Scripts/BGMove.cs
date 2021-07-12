using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove : MonoBehaviour
{

    // 배경 이미지를 아래쪽 방향으로 스크롤 시키고 싶다.
    // 스크롤 방향, 스크롤 속력, Material과 변화시키고자 하는 uv축


    public float scrollSpeed = 1.0f;
     Material backMat;

    // Start is called before the first frame update
    void Start()
    {
        // 메쉬 렌더러에서 머티리얼을 가져온다.
        backMat = GetComponent<MeshRenderer>().material;
        

    }

    // Update is called once per frame
    void Update()
    {

        // 머터리얼의 uv오프셋에서 y축 값을 증가시킨다. // 프로퍼티를 설정(set) 하였다.
        // 달려있는 게임 오브젝트의 메터리얼의 0번(Main) 텍스쳐의 오프셋을 스크롤스피드만큼 시간이 지날수록 누적한다.
        backMat.mainTextureOffset += new Vector2(0,-1f) * scrollSpeed * Time.deltaTime;
    }
}
