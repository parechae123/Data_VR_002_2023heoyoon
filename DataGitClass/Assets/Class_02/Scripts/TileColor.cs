using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileColor : MonoBehaviour      //Ÿ�� ������Ʈ�� ���� Ŭ����(prefabs)
{
    public Renderer rend;
    public enum TerrainEnum : int       // ���ڷ� Ÿ���� �����ϱ� �����ؼ� int ���� byte�ε� �Ͻô� �е鵵 ����
    {
        GRASS,
        SAND,
        WATER,
        WALL
    }

    public TerrainEnum TileColorType;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();        //�巡�׾ص�� ��� �ڵ�� �ִ´�.

        if(TileColorType == TerrainEnum.GRASS)
        {
            rend.material.SetColor("_Color", Color.green);
        }
        if (TileColorType == TerrainEnum.SAND)
        {
            rend.material.SetColor("_Color", Color.yellow);
        }
        if (TileColorType == TerrainEnum.WATER)
        {
            rend.material.SetColor("_Color", Color.blue);
        }
        if (TileColorType == TerrainEnum.WALL)
        {
            rend.material.SetColor("_Color", Color.grey);
        }
    }
}
