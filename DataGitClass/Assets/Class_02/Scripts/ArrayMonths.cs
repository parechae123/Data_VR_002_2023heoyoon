using System.Collections;
using System.Collections.Generic;
using System.Globalization;         //월 데이터를 활용하기 위하여 사용 됨
using System;                       //DataTime 을 가져오기 위해서 추가
using UnityEngine;

public class ArrayMonths : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string[] months = new string[12]; //12개의 문자열 배열을 선언한다.

        for(int month = 1; month <= 12; month++)
        {
            DateTime firstday = new DateTime(DateTime.Now.Year, month, 1);
            string name = firstday.ToString("MMM", CultureInfo.CreateSpecificCulture("zh-CN"));
            months[month - 1] = name; // for문을 1부터 시작해서 0부터 시작하게 보정
        }
        foreach(string month in months)
        {
            Debug.Log(month);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
