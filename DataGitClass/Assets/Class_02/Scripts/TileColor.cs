using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileColor : MonoBehaviour      //타일 오브젝트에 쓰일 클래스(prefabs)
{
    public Renderer rend;
    public enum TerrainEnum : int       // 숫자로 타일을 구분하기 ㅜ이해서 int 선언 byte로도 하시는 분들도 있음
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
        rend = GetComponent<Renderer>();        //드래그앤드랍 대신 코드로 넣는다.

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
