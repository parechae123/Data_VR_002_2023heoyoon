using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PositionList : MonoBehaviour           //나와  2거리 이상에 있는것을 정렬
{
    public List<Vector3> positionList;              //원본 Vector 리스트를 가져오기 위해서 선언
    public List<Vector3> filter_positionList;       //필터 후 정렬할 리스트
    // Start is called before the first frame update
    void Start()
    {
        /*NormalFuntion();*/
        LINQFunction();
    }
    public void LINQFunction()
    {
        filter_positionList = new List<Vector3>();
        filter_positionList = positionList.Where(n => Vector3.Distance(transform.position, n) > 2f)
            .OrderBy(n => Vector3.Distance(transform.position, n))
            .ToList();
    }
    /*
    public void NormalFuntion()
    {
        filter_positionList = new List<Vector3>();
        List<Vector3> pre_filter_positionList = new List<Vector3>();            //temp List 선언
        for(int i = 0; i < positionList.Count; i++)
        {
            if(Vector3.Distance(transform.position, positionList[i])> 2f)       //나와 2f 거리 이상 감지 함수
            {
                pre_filter_positionList.Add(positionList[i]);
            }
        }
        for(int i = 0; i<pre_filter_positionList.Count; i++)
        {
            int I_higherNum = 0;
            for(int j = 0; j< filter_positionList.Count; i++)
            {
                //앞과 뒤의 거리를 계산
                if(Vector3.Distance(transform.position,pre_filter_positionList[i]) > Vector3.Distance(transform.position, filter_positionList[j]))
                {
                    I_higherNum++;
                }
            }
            filter_positionList.Insert(I_higherNum, pre_filter_positionList[i]);
        }
    }*/
}
