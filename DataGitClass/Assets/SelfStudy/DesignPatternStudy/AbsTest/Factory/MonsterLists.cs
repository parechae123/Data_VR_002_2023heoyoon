using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLists : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public class Goblin : MonsterType
{
    public override void MonsterRace()
    {
        Debug.Log("绊喉赴捞局克");
    }
}
public class Wolf : MonsterType
{
    public override void MonsterRace()
    {
        Debug.Log("戳措局克");
    }
}
