using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackReverse : MonoBehaviour
{
    Stack<int> stackNumber = new Stack<int>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<10; i++)
        {
            stackNumber.Push(i);                                    //push 스택에 밀어넣는 함수
        }
        string temp = "";
        while (stackNumber.Count > 0)
        {
            temp += stackNumber.Pop().ToString() + " / ";             //pop 스택의 맨 위에 있는 것을 빼낸다
        }
        Debug.Log(temp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
