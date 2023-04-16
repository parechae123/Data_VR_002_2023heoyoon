using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class QueueStudy : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 10;
    public float timeChecker = 0;
    public Queue<Vector3> lastPosition = new Queue<Vector3>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
        timeChecker += Time.deltaTime;
        if(timeChecker> 0.2f)
        {
            lastPosition.Enqueue(transform.position);
            timeChecker = 0;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(TimeLoop());
            Debug.Log("E눌림");
        }
    }
    IEnumerator TimeLoop()
    {
        for (; lastPosition.Count > 1;)
        {
            Debug.Log("포문 실행");
            transform.position = lastPosition.Dequeue();
            yield return new WaitForSeconds(0.01f);
            Debug.Log("시간역행");
        }
    }
}
