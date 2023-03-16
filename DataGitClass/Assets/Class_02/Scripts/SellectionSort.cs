using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellectionSort : MonoBehaviour
{
    public int NumberOfCubes = 10;
    public int CubeHeightMax = 10;
    public GameObject[] Cubes;
    // Start is called before the first frame update
    void Start()
    {
        InitializeRandom();
        StartCoroutine(SelectionSort(Cubes));
    }

    void InitializeRandom()
    {
        Cubes = new GameObject[NumberOfCubes]; //10개 큐브를 생성한다
        for(int i = 0; i <NumberOfCubes; i++)
        {
            int randomNumber = Random.Range(1, CubeHeightMax + 1);
            GameObject Temp = GameObject.CreatePrimitive(PrimitiveType.Cube); //CreatePrimitive더 공부해야함
            Temp.transform.localScale = new Vector3(0.9f, randomNumber / 2.0f, 1);
            Temp.transform.position = new Vector3(i - 5, randomNumber / 4.0f, -1);
            Temp.transform.parent = this.transform;                                     //부모 오브젝트 하이러키 안쪽에 넣는다.
            Cubes[i] = Temp;
        }
    }

    IEnumerator SelectionSort(GameObject[] unsortList)      //GameObject 길이동안 반복
    {
        int min;
        GameObject temp;
        Vector3 tempPosition;

        for(int i = 0; i< unsortList.Length; i++)       // for 문 안에서 1초씩 끊어서 동작을 보여준다
        {
            min = i;
            yield return new WaitForSeconds(1);
            for(int j = i+1;  j <unsortList.Length; j++)
            {
                if(unsortList[j].transform.localScale.y < unsortList[min].transform.localScale.y)
                {   //높이를 비교하여서 변경할 것을 선정
                    min = j;
                }
            }
            if(min != 1)//변경이 필요한 경우
            {
                yield return new WaitForSeconds(1);
                temp = unsortList[i];
                unsortList[i] = unsortList[min];
                unsortList[min] = temp;         //배열에서의 위치 교환을 한다.
                tempPosition = unsortList[i].transform.localPosition; //실제로 화면에서 교체되어야할 위치를 선정

                LeanTween.moveLocalX(unsortList[i], unsortList[min].transform.localPosition.x, 1);
                LeanTween.moveLocalZ(unsortList[i], -3, 0.5f).setLoopPingPong(1);

                LeanTween.moveLocalX(unsortList[min], tempPosition.x, 1);
                LeanTween.moveLocalZ(unsortList[min], 3, 0.5f).setLoopPingPong(1);
            }
            LeanTween.color(unsortList[i], Color.green, 1.0f);//교체될 것을 초록색으로 교체
        }
    }
}
