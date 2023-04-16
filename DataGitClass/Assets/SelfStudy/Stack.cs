using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;


public class Stack : MonoBehaviour
{
    public Stack<Vector3> playerPos = new Stack<Vector3>();
    public float delay = 0;
    public float time = 0;
    public float moveSpeed = 10;
    [SerializeField]public List<Vector3> revPos = new List<Vector3>(10);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
        delay += Time.deltaTime;
        time += Time.deltaTime;
        if (delay > 0.2f && playerPos.Count <= 10)
        {
            playerPos.Push(transform.position);
            Debug.Log(playerPos.Count);
            delay = 0;
        }
        if (playerPos.Count > 10 && time > 2)
        {
            revPos = playerPos.ToList();
            revPos.RemoveAt(9);
            revPos.Reverse();
            playerPos = new Stack<Vector3>(revPos);
            //Stack은 선입선출로 먼저 넣은애만 제거할 수 있으니 LIST로 왔다갔다 하면서 배열을 비워준다,근데 이러면 그냥 리스트로 하는게 낫지않나?
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(TimeLoop());

        }

    }
    IEnumerator TimeLoop()
    {
        for (; playerPos.Count > 1;)
        {
            transform.position = playerPos.Pop();
            yield return new WaitForSeconds(0.04f);
            Debug.Log("시간역행");
        }
    }
}
