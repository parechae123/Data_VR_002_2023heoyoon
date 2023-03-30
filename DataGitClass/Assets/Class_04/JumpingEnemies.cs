using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemies : MonoBehaviour
{
    public float jumpForce = 5f;
    public float jumpInterval = 1f;

    private Queue<GameObject> enemyQueue = new Queue<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetJumpEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddEnemyToQueue();
        }
    }

    void AddEnemyToQueue()
    {
        GameObject enemy = GameObject.CreatePrimitive(PrimitiveType.Cube);                          //������Ƽ�� ť�� ����
        enemy.transform.position = new Vector3(Random.Range(-5, 5), 0.5f, Random.Range(-5, 5));     //-5,5 ������ �������� ����
        enemy.AddComponent<Rigidbody>();                                                            //���� rigidbody �ٿ��ش�.
        enemyQueue.Enqueue(enemy);                                                                  //ť�� �ִ´�
    }
    IEnumerator SetJumpEnemies()                                               //���� ���ѷ��� �ڷ�ƾ
    {
        while (true)
        {
            if(enemyQueue.Count > 0)                                        //�����ϴ� ť�� ������Ʈ��
            {
                GameObject enemy = enemyQueue.Dequeue();                    //������Ʈ �ϳ��� ������.
                Rigidbody rb = enemy.GetComponent<Rigidbody>();
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);     //���������� ������ ��Ų��.
                yield return new WaitForSeconds(jumpInterval);              //���� ���� ���� �ð�
                Destroy(enemy);                                             //���� ������Ʈ �ı�
            }
            yield return null;
        }

    }
}
