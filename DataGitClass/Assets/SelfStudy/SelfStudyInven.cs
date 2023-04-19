using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfomations       //아이템 안에 들어갈 리스트들
{
    public string itemName;
    public string itemImagePath;
    public int amount;
}
public class invenDict
{
    public Image invenIcons;
    public Text amountOutput;
    public byte slotAmount;
    public bool isFull;
}
public class SelfStudyInven : MonoBehaviour
{
    public Dictionary<int/*아이템식별값 템코드*/, ItemInfomations> selfStudyItemDictionary = new Dictionary<int, ItemInfomations>()
    {
        { 0 ,new ItemInfomations{itemName = "Apple",itemImagePath = "Realistic Generated Icons/Arcane Magic/9f16f60d-bc98-4134-9ff1-17b23f1ed001" ,amount = 0}},
        { 1 ,new ItemInfomations{itemName = "Banana",itemImagePath = "Realistic Generated Icons/Arcane Magic/80aeb5ff-9554-45d6-ac72-951423bb1cd3" ,amount = 0}},
    };
    public Dictionary<byte, invenDict> invenDict = new Dictionary<byte, invenDict>();
    public byte itemStackMax = 255;
    // Start is called before the first frame update
    void Start()
    {
        for (byte i =0; transform.childCount>i;i++)
        {
            invenDict.Add(i, new invenDict {invenIcons = transform.GetChild(i).GetComponent<Image>(), amountOutput=transform.GetChild(i).GetChild(0).GetComponent<Text>(),isFull = false });
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GetItem(0,10);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            GetItem(1,10);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            UseItem(0,10);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            UseItem(1,10);
        }
    }
    public void GetItem(int infoIndex, byte addAmount)
    {
        for (byte i = 0; invenDict.Count > i; i++)
        {
            /*            int remainValues = invenDict[i].slotAmount+addAmount% itemStackMax;
                        if (invenDict[i].invenIcons.sprite == Resources.Load<Sprite>(selfStudyItemDictionary[infoIndex].itemImagePath) && ((int)invenDict[i].slotAmount+addAmount < itemStackMax))
                        {
                            selfStudyItemDictionary[infoIndex].amount += addAmount;//인벤 내 아이템의 갯수
                            invenDict[i].slotAmount += addAmount;                //슬롯 내 아이템의 갯수
                            Debug.Log("중첩");
                            invenDict[i].amountOutput.text = invenDict[i].slotAmount.ToString();
                            break;
                        }
                        if (invenDict[i].invenIcons.sprite == Resources.Load<Sprite>(selfStudyItemDictionary[infoIndex].itemImagePath) && ((int)invenDict[i].slotAmount + addAmount) > itemStackMax)//여기가 다음 실행때 실행 안되도록 해야됨
                        {
                            invenDict[i].slotAmount = itemStackMax;
                            invenDict[i].amountOutput.text = itemStackMax.ToString();
                            Debug.Log((remainValues));
                            for (byte f = 0; f < invenDict.Count; f++)
                            {
                                if (invenDict[f].slotAmount + remainValues > itemStackMax)
                                {
                                    if(invenDict[f].invenIcons.sprite == null)
                                    {
                                        Debug.Log("나누기");
                                        invenDict[f].invenIcons.sprite = Resources.Load<Sprite>(selfStudyItemDictionary[infoIndex].itemImagePath);
                                        invenDict[f].slotAmount += (byte)remainValues;
                                        invenDict[f].amountOutput.text = invenDict[f].slotAmount.ToString();
                                        break;
                                    }
                                }
                            }
                            break;
                        }*/
            if (invenDict[i].slotAmount+addAmount <= itemStackMax && invenDict[i].invenIcons.sprite == Resources.Load<Sprite>(selfStudyItemDictionary[infoIndex].itemImagePath))
            {
                selfStudyItemDictionary[infoIndex].amount += addAmount;//인벤 내 아이템의 갯수
                invenDict[i].slotAmount += addAmount;                //슬롯 내 아이템의 갯수
                invenDict[i].amountOutput.text = invenDict[i].slotAmount.ToString();
                break;
            }
            if (invenDict[i].slotAmount + addAmount >= itemStackMax && invenDict[i].isFull == false)
            {
                invenDict[i].isFull = true;
                int remainAmount = (invenDict[i].slotAmount + addAmount)%255;
                selfStudyItemDictionary[infoIndex].amount += addAmount;//인벤 내 아이템의 갯수
                invenDict[i].slotAmount = 255;                //슬롯 내 아이템의 갯수
                invenDict[i].amountOutput.text = invenDict[i].slotAmount.ToString();
                for (byte j = 0; invenDict.Count>j;j++)
                {
                    if (invenDict[j].isFull == false&& invenDict[j].invenIcons.sprite == null)
                    {
                        invenDict[j].slotAmount += (byte)remainAmount;                //슬롯 내 아이템의 갯수
                        invenDict[j].invenIcons.sprite = Resources.Load<Sprite>(selfStudyItemDictionary[infoIndex].itemImagePath);
                        invenDict[j].amountOutput.text = invenDict[j].slotAmount.ToString();
                        break;
                    }
                }
                break;
            }
            if (invenDict[i].invenIcons.sprite ==null&& !invenDict[i].isFull)
            {
                invenDict[i].slotAmount += addAmount;                       //슬롯 내 아이템의 갯수
                selfStudyItemDictionary[infoIndex].amount += addAmount;     //인벤 내 아이템의 갯수
                invenDict[i].amountOutput.text = invenDict[i].slotAmount.ToString();
                invenDict[i].invenIcons.sprite = Resources.Load<Sprite>(selfStudyItemDictionary[infoIndex].itemImagePath);//여기다가 이프문으로 구분주면 각 배열에 배치 가능할듯함 slots[i]로 변경필요
                break;
            }
        }
    }
    public void UseItem(int itemIndex,byte delAmount)
    {
        for (byte i = 0; invenDict.Count > i; i++)
        {
            if (invenDict[i].slotAmount > 0 && invenDict[i].invenIcons.sprite == Resources.Load<Sprite>(selfStudyItemDictionary[itemIndex].itemImagePath))
            {
                invenDict[i].slotAmount -= delAmount;
                selfStudyItemDictionary[itemIndex].amount -= delAmount;
                invenDict[i].amountOutput.text = invenDict[i].slotAmount.ToString();
                if (invenDict[i].slotAmount <= 0)
                {
                    invenDict[i].invenIcons.sprite = null;
                    invenDict[i].amountOutput.text = " ";
                    break;
                }
                break;
            }

        }
    }
}
