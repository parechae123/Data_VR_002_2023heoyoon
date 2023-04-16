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
    Dictionary<string, studyItem> selfItem = new Dictionary<string/*아이템이름*/, studyItem/*아이템 속성*/>();
    // Start is called before the first frame update
    void Start()
    {
        studyItem STDitem = new studyItem {itemName = "사과",itemNumber = 000001,type = studyItem.itemType.Fruits };
        selfItem.Add("Apple",STDitem);
        Debug.Log(selfItem["Apple"]);//딕셔너리에서 제일 앞에있는 키값이 배열의 이름이됨
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
