using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MyItem         //�� ������ Ÿ�� ����
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
    public MyNode<T> head;          //���� ���
    public MyNode<T> tail;          //���� ���
    public uint length = 0;         //����
    public MyLinkedList()
    {
        head = new MyNode<T>()      //null ������ �ʱ�ȭ
        {
            myItem = null
        };
        tail = new MyNode<T>()      //null ������ �ʱ�ȭ
        {
            myItem = null
        };
        head.prevNode = null;       //head �տ� �ִ� ���� ���� ������ Null
        head.nextNode = tail;       //head �ٷ� �� ���� tail head => tail

        tail.prevNode = head;       //tail�� �� ���� head
        tail.nextNode = null;       //tail�� �޳��� ����.
    }
    public bool IsEmpty()
    {
        return (length == 0);
    }
    public void Print()
    {
        MyNode<T> searchNode = head;
        Debug.Log("======����===========");
        while (searchNode.nextNode != tail)         //head���� tail����
        {
            Debug.Log(searchNode.nextNode.myItem.ItemName);     //���� ����Ʈ���� ��ĭ�� ���ư��鼭 ������
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
            head.nextNode = newNode;            //head�� ���� ���� ���ο� ���
            newNode.prevNode = head;            //���ο� ��� ���� head
            newNode.nextNode = tail;            //���ο� ����� �ڴ� tail
            tail.prevNode = newNode;            //tail�� ���� ���� ���ο� ���
            Debug.Log(_value.ItemName + "�� ó������ ���濡 �־����ϴ�.");
        }
        else
        {
            MyNode<T> searchNode = head;
            while (searchNode.nextNode != tail)         //head���� tail����
            {    
                searchNode = searchNode.nextNode;       //tail ������ ��带 searchNode ����� ����
            }
            searchNode.nextNode.prevNode = newNode;     //ã�� ����� �պκ��� ���ο� ���
            newNode.nextNode = searchNode.nextNode;     //���ο� ����� ���� ���� ã�� ����� �������
            newNode.prevNode = searchNode;              //���ο� ����� ���� ���� ��ġ ���
            searchNode.nextNode = newNode;              //��ġ����� ������ ���ο� ���
            Debug.Log(_value.ItemName + "�� ���濡 �־����ϴ�.");
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
                Debug.Log(_value.ItemName + "�� �����ϴ�.");
                --length;
                return;
            }
            searchNode = searchNode.nextNode;
        }
        Debug.Log("�� " + _value.ItemName + "�� �����ϴ�.");
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
            temp.ItemName = "HP ����";
            temp.itemType = 1;
            linkedList.Add(temp);
        }        
        if (Input.GetKeyDown(KeyCode.W))
        {
            MyItem temp = new MyItem();
            temp.ItemName = "������";
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
            temp.ItemName = "HP ����";
            temp.itemType = 1;
            linkedList.Remove(temp);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            MyItem temp = new MyItem();
            temp.ItemName = "������";
            temp.itemType = 2;
            linkedList.Remove(temp);
        }
    }
}
