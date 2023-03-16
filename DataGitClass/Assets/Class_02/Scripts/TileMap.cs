using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TileQuad;
    public enum TerrainEnum : int       //TerrainEnum 선언
    {
        GRASS,
        SAND,
        WATER,
        WALL
    }

    public TerrainEnum[,] map =         //맵 데이터 생성
    {
        {TerrainEnum.SAND,TerrainEnum.SAND,TerrainEnum.SAND,TerrainEnum.SAND,TerrainEnum.WALL },
        {TerrainEnum.GRASS,TerrainEnum.GRASS,TerrainEnum.WATER,TerrainEnum.SAND,TerrainEnum.WALL },
        {TerrainEnum.GRASS,TerrainEnum.GRASS,TerrainEnum.WATER,TerrainEnum.SAND,TerrainEnum.WALL },
        {TerrainEnum.GRASS,TerrainEnum.GRASS,TerrainEnum.WATER,TerrainEnum.SAND,TerrainEnum.WALL },
        {TerrainEnum.GRASS,TerrainEnum.GRASS,TerrainEnum.WATER,TerrainEnum.WATER,TerrainEnum.WATER },
        {TerrainEnum.SAND,TerrainEnum.SAND,TerrainEnum.WATER,TerrainEnum.WALL,TerrainEnum.WALL },
        {TerrainEnum.SAND,TerrainEnum.SAND,TerrainEnum.WATER,TerrainEnum.WALL,TerrainEnum.WALL }
    };

    void Start()
    {
        for(int row = 0; row < map.GetLength(0); row++)
        {
            for(int column = 0; column < map.GetLength(1); column++)
            {
                GameObject Temp = (GameObject)Instantiate(TileQuad);        //프리팹 타일을 생성한 이후 temp에 넣어준다.
                Temp.transform.position = new Vector3(column, -row, 0);     //temp 에 포지션을 정해준다.
                //TileColor 에 접근해서 타일 맵에 정의된 내용대로 배치를 한다.
                Temp.GetComponent<TileColor>().TileColorType = (TileColor.TerrainEnum)map[row, column];
            }
        }
    }

}
