using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour {

    //어떤 공을 빨아들일지를 태그로 지정
    public string activeTag;

    private void OnTriggerStay(Collider other)
    {
        //콜라이더에 접촉하고 있는 오브젝트의 Rigidbody 컴퍼넌트 취득
        Rigidbody r = other.gameObject.GetComponent<Rigidbody>();

        //공이 어떤 방향에 있는지를 계산
        Vector3 direction = transform.position - other.gameObject.transform.position;
        direction.Normalize();

        //태그에 따라 공에 힘을 더한다.
        if(other.gameObject.tag == activeTag)
        {
            //중심 지점에서 공을 멈추기 위해 속도를 감소 시킨다.
            r.velocity *= 0.9f;

            r.AddForce(direction * r.mass * 20.0f);
        }
        else
        {
            r.AddForce(-direction * r.mass * 80.0f);
        }
    }
}
