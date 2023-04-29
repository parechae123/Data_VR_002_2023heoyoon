using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestAndSleep : FSMStates
{
    public override void Enter(Student entity)
    {
        entity.CurrentLocations = Locations.SweetHome;
        entity.Stress = 0;
        entity.PrintText("���� ������. �ູ�� �츮�� ��¼��");
        entity.PrintText("���� ħ�뿡 ���� ���� �ܴ� ��¼��");
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
        entity.PrintText("ħ�븦 �����ϰ� �� ������ ������.");
    }
}
