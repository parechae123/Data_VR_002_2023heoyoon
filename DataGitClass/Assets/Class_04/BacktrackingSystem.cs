using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacktrackingSystem : MonoBehaviour
{
    private Stack<Vector3> positionStack = new Stack<Vector3>();        //스택 Vector3 위치값 저장 모델
    public float speed = 5f;                                            //이동속도
    private Rigidbody rb;                                               //물리 컴포넌트
    public float checkTime = 0.0f;                                      //반복되는 시간 설정하기 위한 변수
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();                                 //캐릭터 컴포넌트 가져오기
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Backspace))                        //백스페이스를 눌렀을때
        {
            if(positionStack.Count > 0)                             //스택이 비어있지 않다면
            {
                Vector3 prevPos = positionStack.Pop();              //스택에서 빼내서 내 위치를 갱신
                transform.position = prevPos;
            }
        }
        checkTime += Time.deltaTime;                                //update 에서 프레임 간격 초를 쌓아서 시간 설정

        if(checkTime > 0.2f)                                        //0.2초마다
        {
            Vector3 currPos = transform.position;                   //지금 위치를 스택에 넣는다.
            positionStack.Push(currPos);
            checkTime = 0.0f;
        }
    }
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        if(movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }
        rb.velocity = movement.normalized * speed;
    }
}
