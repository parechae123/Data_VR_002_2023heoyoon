using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorotineSystem : MonoBehaviour
{
    // Start is called before the first frame update
    private Queue coroutineQueue = new Queue();                         //�ڷ�ƾ �����ϴ� ť �ڷᱸ��
    public void AddCoroutineQueue(IEnumerator coroutine)                //������ �ڷ�ƾ add�Լ�
    {
        coroutineQueue.Enqueue(coroutine);                              //�Լ��� ���ؼ� �ڷ�ƾ�� �޴´�
    }
    void Start()
    {
        AddCoroutineQueue(Logging(10));
        AddCoroutineQueue(Logging(100));
        AddCoroutineQueue(Logging(1000));
        if (coroutineQueue.Count > 0)                                   //���������� �ڷ�ƾ�� ť�� �׿��ִٸ� �ϳ� ������ ����    
        {
            StartCoroutine((IEnumerator)coroutineQueue.Dequeue());
        }
    }

    IEnumerator Logging(int number)                                     //�α�
    {
        for(int i = number; i < number + 10; i++)
        {
            Debug.Log(i.ToString() + "<---");
            yield return new WaitForSeconds(0.1f);
        }
        if(coroutineQueue.Count > 0)
        {
            StartCoroutine((IEnumerator)coroutineQueue.Dequeue());
        }

    }
}
