using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashTableExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Hashtable hashtable = new Hashtable();          //해시 테이블 선억
        //키-값 쌍 추가 (개인주석 : 인벤토리에 사용 가능할듯함)
        hashtable.Add("Apple", 3);
        hashtable.Add("Banana", 5);
        hashtable.Add("Orange",2);

        //값 검색
        int appleCount = (int)hashtable["Apple"];
        Debug.Log("Apple count : " + appleCount);

        //키-값 쌍 추가
        hashtable["Apple"] = 4;
        // 키-값 삭제
        hashtable.Remove("Banana");

        //값 검색
        int appleCount2 = (int)hashtable["Apple"];
        Debug.Log("Apple Count : " + appleCount2);
        //유니티 연결 누른 후 유니티에서 실행하고 조사식에다가 변수 !!이름만!! 조사식에 끌어놓기(스크립트는 반드시 씬 내에 넣어놔야됨)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
