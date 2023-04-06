using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InventoryExample : MonoBehaviour
{
    // Start is called before the first frame update
    public InventoryManager inventoryManager;                   //매니저를 받아온다.
    void Start()
    {
        Item apple = new Item { itemName = "Apple", itemID = 1, itemCount = 3 };        //아이템 생성
        Item banana = new Item { itemName = "Banana", itemID = 2, itemCount = 5 };
        Item orange = new Item { itemName = "Orange", itemID = 3, itemCount = 2 };

        inventoryManager.AddItem(apple);        //생성한 아이템을 입력
        inventoryManager.AddItem(banana);
        inventoryManager.AddItem(orange);

        inventoryManager.PrintInventory();      //프린트
        inventoryManager.RemoveItem(2, 3);
        inventoryManager.PrintInventory();
        
        var sortedByValue = inventoryManager.inventory.OrderBy(pair => pair.Value.itemCount).ToDictionary(pair => pair.Value.itemName, pair => pair.Value.itemCount);       //아이템 갯수 순서대로 정렬
        foreach(KeyValuePair<string,int> entry in sortedByValue)        //실제 아이템 정렬이 바뀌는건 아님 그러면 난리난당
        {
            Debug.Log("Key : " + entry.Key + "value : " + entry.Value); //프린팅 한다
        }
    }
}
