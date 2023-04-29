using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestAndSleep : FSMStates
{
    public override void Enter(Student entity)
    {
        entity.CurrentLocations = Locations.SweetHome;
        entity.Stress = 0;
        entity.PrintText("집에 들어오다. 행복한 우리집 어쩌구");
        entity.PrintText("집에 침대에 누워 잠을 잔다 저쩌구");
    }
    public override void Execute(Student entity)
    {
        if(entity.Fatigue > 0)
        {
            entity.Fatigue -= 10;
        }
        else
        {

        }
    }
    public override void Exit(Student entity)
    {
        entity.PrintText("침대를 정리하고 집 밖으로 나간다.");
    }
}
