using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum Locations { SweetHome = 0,Library,LectureRoom,PCRoom,Pub};
public class GameController : MonoBehaviour
{
    [SerializeField]
    private string[] arrayStudents;
    [SerializeField]
    private GameObject studentPrefab;
    private List<BaseGameEntity> entitys;
    private void Awake()
    {
        entitys = new List<BaseGameEntity>();
        for(int i = 0; i < arrayStudents.Length; ++i)
        {
            GameObject clone = Instantiate(studentPrefab);
            Student entity = clone.GetComponent<Student>();
            entity.Setup(arrayStudents[i]);
            entitys.Add(entity);
        }
    }
    private void Update()
    {
        for(int i = 0; i< entitys.Count; ++ i)//������Ʈ�� �ݺ���?..
        {
            entitys[i].Updated();//��� ��ƼƼ�� �ݺ����� ȣ��
        }
    }
}
