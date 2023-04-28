using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Student : BaseGameEntity
{
    private int knowlege;
    private int stress;
    private int fatigue;
    private int totalScore;
    private Locations currentLocation;
    // Start is called before the first frame update
    public int Knowledge
    {
        set => Knowledge = Mathf.Max(0, value);
        get => knowlege;
    }
    public int Stress
    {
        set => stress = Mathf.Max(0, value);
        get => stress;
    }
    public int Fatigue
    {
        set => fatigue = Mathf.Max(0, value);
        get => fatigue;
    }
    public int TotalScroe
    {
        set => totalScore = Mathf.Clamp(value, 0,100);
    }
    public Locations CurrentLocations
    {
        set => currentLocation = value;
        get => currentLocation;
    }
    public override void Updated()
    {
        PrintText("대기중입니다...");
    }
}
