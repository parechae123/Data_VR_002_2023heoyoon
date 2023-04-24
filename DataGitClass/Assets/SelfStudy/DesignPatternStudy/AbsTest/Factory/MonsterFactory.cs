using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFactory 
{
    public MonsterType CreateEnemy(string enemyType)
    {
        switch (enemyType)
        {
            case "Wolf":
                return new Wolf();
            case "Goblin":
                return new Goblin();
            default:
                throw new System.NotSupportedException(string.Format("The enemy type {0} is not supported", enemyType));
        }
    }
}
