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
        Cubes = new GameObject[NumberOfCubes]; //10�� ť�긦 �����Ѵ�
        for(int i = 0; i <NumberOfCubes; i++)
        {
            int randomNumber = Random.Range(1, CubeHeightMax + 1);
            GameObject Temp = GameObject.CreatePrimitive(PrimitiveType.Cube); //CreatePrimitive�� �����ؾ���
            Temp.transform.localScale = new Vector3(0.9f, randomNumber / 2.0f, 1);
            Temp.transform.position = new Vector3(i - 5, randomNumber / 4.0f, -1);
            Temp.transform.parent = this.transform;                                     //�θ� ������Ʈ ���̷�Ű ���ʿ� �ִ´�.
            Cubes[i] = Temp;
        }
    }

    IEnumerator SelectionSort(GameObject[] unsortList)      //GameObject ���̵��� �ݺ�
    {
        int min;
        GameObject temp;
        Vector3 tempPosition;

        for(int i = 0; i< unsortList.Length; i++)       // for �� �ȿ��� 1�ʾ� ��� ������ �����ش�
        {
            min = i;
            yield return new WaitForSeconds(1);
            for(int j = i+1;  j <unsortList.Length; j++)
            {
                if(unsortList[j].transform.localScale.y < unsortList[min].transform.localScale.y)
                {   //���̸� ���Ͽ��� ������ ���� ����
                    min = j;
                }
            }
            if(min != 1)//������ �ʿ��� ���
            {
                yield return new WaitForSeconds(1);
                temp = unsortList[i];
                unsortList[i] = unsortList[min];
                unsortList[min] = temp;         //�迭������ ��ġ ��ȯ�� �Ѵ�.
                tempPosition = unsortList[i].transform.localPosition; //������ ȭ�鿡�� ��ü�Ǿ���� ��ġ�� ����

                LeanTween.moveLocalX(unsortList[i], unsortList[min].transform.localPosition.x, 1);
                LeanTween.moveLocalZ(unsortList[i], -3, 0.5f).setLoopPingPong(1);

                LeanTween.moveLocalX(unsortList[min], tempPosition.x, 1);
                LeanTween.moveLocalZ(unsortList[min], 3, 0.5f).setLoopPingPong(1);
            }
            LeanTween.color(unsortList[i], Color.green, 1.0f);//��ü�� ���� �ʷϻ����� ��ü
        }
    }
}
