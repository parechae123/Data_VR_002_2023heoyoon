using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class studyItem
{
    public string itemName;
    public int itemNumber;
    public enum itemType
    {
        Potions,Fruits,Weapon,Equipments
    }
    public itemType type;
}
public class DictionarySelfStudy : MonoBehaviour
{
    Dictionary<string, studyItem> selfItem = new Dictionary<string/*�������̸�*/, studyItem/*������ �Ӽ�*/>();
    // Start is called before the first frame update
    void Start()
    {
        studyItem STDitem = new studyItem {itemName = "���",itemNumber = 000001,type = studyItem.itemType.Fruits };
        selfItem.Add("Apple",STDitem);
        Debug.Log(selfItem["Apple"]);//��ųʸ����� ���� �տ��ִ� Ű���� �迭�� �̸��̵�
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
