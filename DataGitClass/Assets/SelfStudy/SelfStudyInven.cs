using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct ItemInfomations       //아이템 안에 들어갈 리스트들
{
    public string itemName;
    public string itemImagePath;
    public byte amount;
}
public class SelfStudyInven : MonoBehaviour
{
    public Dictionary<int/*아이템식별값 템코드*/, ItemInfomations> selfStudyItemDictionary = new Dictionary<int, ItemInfomations>()
    {
        { 0 ,new ItemInfomations{itemName = "Apple",itemImagePath = "Realistic Generated Icons/Arcane Magic/9f16f60d-bc98-4134-9ff1-17b23f1ed001" ,amount = 0}},
        { 1 ,new ItemInfomations{itemName = "Banana",itemImagePath = "Realistic Generated Icons/Arcane Magic/80aeb5ff-9554-45d6-ac72-951423bb1cd3" ,amount = 0}},
    };
    public List<Image> Slots = new List<Image>();
    // Start is called before the first frame update
    void Start()
    {
        for (byte i =0; transform.childCount>i;i++)
        {
            Slots.Add(transform.GetChild(i).GetComponent<Image>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GetItem(0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            GetItem(1);
        }
    }
    public void GetItem(int infoIndex)
    {
        Slots[0].sprite = Resources.Load<Sprite>(selfStudyItemDictionary[infoIndex].itemImagePath);//여기다가 이프문으로 구분주면 각 배열에 배치 가능할듯함 slots[i]로 변경필요
    }
}
