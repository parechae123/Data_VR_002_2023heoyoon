using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinProdLine : MonoBehaviour
{
    private MonsterFactory monsterFactory;
    private void Start()
    {
        monsterFactory = new MonsterFactory();
        MonsterType Wolf = monsterFactory.CreateEnemy("Wolf");
        Wolf.MonsterRace();
        MonsterType Gblin = monsterFactory.CreateEnemy("Goblin");
        Gblin.MonsterRace();
    }
}
