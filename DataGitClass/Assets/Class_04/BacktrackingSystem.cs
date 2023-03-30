using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacktrackingSystem : MonoBehaviour
{
    private Stack<Vector3> positionStack = new Stack<Vector3>();        //���� Vector3 ��ġ�� ���� ��
    public float speed = 5f;                                            //�̵��ӵ�
    private Rigidbody rb;                                               //���� ������Ʈ
    public float checkTime = 0.0f;                                      //�ݺ��Ǵ� �ð� �����ϱ� ���� ����
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();                                 //ĳ���� ������Ʈ ��������
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Backspace))                        //�齺���̽��� ��������
        {
            if(positionStack.Count > 0)                             //������ ������� �ʴٸ�
            {
                Vector3 prevPos = positionStack.Pop();              //���ÿ��� ������ �� ��ġ�� ����
                transform.position = prevPos;
            }
        }
        checkTime += Time.deltaTime;                                //update ���� ������ ���� �ʸ� �׾Ƽ� �ð� ����

        if(checkTime > 0.2f)                                        //0.2�ʸ���
        {
            Vector3 currPos = transform.position;                   //���� ��ġ�� ���ÿ� �ִ´�.
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
