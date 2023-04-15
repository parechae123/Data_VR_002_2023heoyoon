using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Analytics;
using Unity.VisualScripting;

public struct testStructure
{
    public string name;
    public byte age;
    public bool isMale;
}
public class LinQAgain : MonoBehaviour
{
    [SerializeField]public List<testStructure> structure = new List<testStructure>();

    // Start is called before the first frame update
    void Start()
    {
        testStructure Yoon;
        testStructure seoYoung;
        testStructure Gyum;
        //구조체란 변수의 집합
        Yoon.name = "HeoYoon";
        Yoon.age = 25;
        Yoon.isMale = true;
        seoYoung.name = "seoYoung";
        seoYoung.age = 27;
        seoYoung.isMale = false;
        Gyum.name = "Gyum";
        Gyum.age = 23;
        Gyum.isMale = true;
        structure.Add(Yoon);
        structure.Add(seoYoung);
        structure.Add(Gyum);
        structure = structure.OrderBy(x => x.age).ToList();     //나이순으로 정렬
        for(byte i = 0;structure.Count > i; i++)
        {
            Tester(structure[i]);
        }
    }
    void Tester(testStructure humanInfo)
    {
        Debug.Log("이름은 무엇입니까? : " + humanInfo.name );
        Debug.Log("나이는? : " + humanInfo.age);
        Debug.Log("남성입니까? : " + humanInfo.isMale);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
