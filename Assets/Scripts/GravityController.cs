using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour {
    //중력 가속도
    const float Gravity = 9.81f;

    //중력 적용 상태
    public float gravityScale = 1.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //중력 벡터 초기화
        Vector3 vector = new Vector3();

        if (Application.isEditor)
        {
            //키 입력을 검출하는 벡터 생성
            vector.x = Input.GetAxis("Horizontal");
            vector.z = Input.GetAxis("Vertical");

            //높이 방향의 판정은 z키로 한다.
            if (Input.GetKey("z"))
            {
                vector.y = 1.0f;
            }
            else
            {
                vector.y = -1.0f;
            }
        }
        else
        {
            //가속도 센서의 입력을 유니티 공간의 축에 매핑한다.
            vector.x = Input.acceleration.x;
            vector.y = Input.acceleration.y;
            vector.z = Input.acceleration.z;
        }
        

        //씬의 중력을 입력 벡터의 방향에 맞추어 변화 시킨다.
        Physics.gravity = Gravity * vector.normalized * gravityScale;
	}
}
