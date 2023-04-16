using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class GenericTester<T>
{
    public T number { get; set; }
}

public struct Students
{
    public string name;
    public byte age;
}
public class GenericStudy : MonoBehaviour
{
    // Start is called before the first frame update
    public GenericTester<int> tester = new GenericTester<int>();
    public GenericTester<string> StringTester = new GenericTester<string>();
    void Start()
    {
        tester.number = 10;
        StringTester.number = "스트링 테스트";
        Debug.Log(tester.number+StringTester.number);
        StringTester.number = "불닭에 스트링치즈";
        tester.number = 100000000;
        Debug.Log($"{tester.number:#,###} " +StringTester.number);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            tester.number = 10;
            StringTester.number = "스트링";
            Debug.Log(tester.number + StringTester.number);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            tester.number = 0;
            StringTester.number = null;
            Debug.Log(tester.number+StringTester.number);
        }
    }
}
