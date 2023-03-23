using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MyItem         //내 아이템 타입 설정
{
    public string ItemName;
    public int itemType;

}
public class MyNode<T> where T : class
{
    public MyItem myItem;
    public MyNode<T> nextNode;
    public MyNode<T> prevNode;
    public string GetMyItemName()
    {
        return myItem.ItemName;
    }
}
public class MyLinkedList<T> where T : class
{
    public MyNode<T> head;          //앞의 노드
    public MyNode<T> tail;          //뒤의 노드
    public uint length = 0;         //길이
    public MyLinkedList()
    {
        head = new MyNode<T>()      //null 값으로 초기화
        {
            myItem = null
        };
        tail = new MyNode<T>()      //null 값으로 초기화
        {
            myItem = null
        };
        head.prevNode = null;       //head 앞에 있는 노드는 없기 때문에 Null
        head.nextNode = tail;       //head 바로 뒷 노드는 tail head => tail

        tail.prevNode = head;       //tail의 앞 노드는 head
        tail.nextNode = null;       //tail의 뒷노드는 없다.
    }
    public bool IsEmpty()
    {
        return (length == 0);
    }
    public void Print()
    {
        MyNode<T> searchNode = head;
        Debug.Log("======가방===========");
        while (searchNode.nextNode != tail)         //head부터 tail까지
        {
            Debug.Log(searchNode.nextNode.myItem.ItemName);     //만든 리스트들을 한칸씩 돌아가면서 프린팅
            searchNode = searchNode.nextNode;
        }
    }

    public void Add(MyItem _value)
    {
        MyNode<T> newNode = new MyNode<T>
        {
            myItem = _value
        };
        if (IsEmpty())
        {
            head.nextNode = newNode;            //head의 다음 노드는 새로운 노드
            newNode.prevNode = head;            //새로운 노드 앞은 head
            newNode.nextNode = tail;            //새로운 노드의 뒤는 tail
            tail.prevNode = newNode;            //tail의 앞의 노드는 새로운 노드
            Debug.Log(_value.ItemName + "를 처음으로 가방에 넣었습니다.");
        }
        else
        {
            MyNode<T> searchNode = head;
            while (searchNode.nextNode != tail)         //head부터 tail까지
            {    
                searchNode = searchNode.nextNode;       //tail 전까지 노드를 searchNode 노드라고 생각
            }
            searchNode.nextNode.prevNode = newNode;     //찾은 노드의 앞부분은 새로운 노드
            newNode.nextNode = searchNode.nextNode;     //새로운 노드의 다음 노드는 찾은 노드의 다음노드
            newNode.prevNode = searchNode;              //새로운 노드의 앞의 노드는 서치 노드
            searchNode.nextNode = newNode;              //서치노드의 다음은 새로운 노드
            Debug.Log(_value.ItemName + "를 가방에 넣었습니다.");
        }
        ++length;
    }
    
    public void Remove(MyItem _value)
    {
        MyNode<T> searchNode = head;
        while (searchNode != tail)         
        {
            if(searchNode.myItem != null && searchNode.myItem.itemType == _value.itemType)
            {
                searchNode.nextNode.prevNode = searchNode.prevNode;
                searchNode.prevNode.nextNode = searchNode.nextNode;
                Debug.Log(_value.ItemName + "를 뺏습니다.");
                --length;
                return;
            }
            searchNode = searchNode.nextNode;
        }
        Debug.Log("뺄 " + _value.ItemName + "가 없습니다.");
    }
    public bool Constrain(MyItem _value)
    {
        MyNode<T> searchNode = head;
        while(searchNode.nextNode != tail)
        {
            if(searchNode.myItem == _value)
            {
                return true;
            }
        }
        return false;
    }
}

public class MyBag : MonoBehaviour
{
    MyLinkedList<string> linkedList = new MyLinkedList<string>();
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            MyItem temp = new MyItem();
            temp.ItemName = "HP 포션";
            temp.itemType = 1;
            linkedList.Add(temp);
        }        
        if (Input.GetKeyDown(KeyCode.W))
        {
            MyItem temp = new MyItem();
            temp.ItemName = "돌맹이";
            temp.itemType = 2;
            linkedList.Add(temp);
        }        
        if (Input.GetKeyDown(KeyCode.E))
        {
            linkedList.Print();
        }        
        if (Input.GetKeyDown(KeyCode.R))
        {
            MyItem temp = new MyItem();
            temp.ItemName = "HP 포션";
            temp.itemType = 1;
            linkedList.Remove(temp);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            MyItem temp = new MyItem();
            temp.ItemName = "돌맹이";
            temp.itemType = 2;
            linkedList.Remove(temp);
        }
    }
}
