using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public enum StudentStates { RestAndSleep = 0,StudyHard,TakeAExam,PlayAGame,HitTheBottle}
public class Student : BaseGameEntity
{
    private int knowlege;
    private int stress;
    private int fatigue;
    private int totalScore;
    private Locations currentLocation;

    public override void Setup(string name)
    {
        /*base.Setup(name);
        gameObject.name = $"{ID:D2}_Student_{name}";
        states = new State[5];
        states[(int)StudentStates.RestAndSleep] = new StateOwnedState.RestAndSleep();
        states[(int)StudentStates.StudyHard] = new StateOwnedState.StudyHard();
        ChangeState(StudentStates.RestAndSleep);
        Knowledge = 0;
        stress = 0;
        fatigue = 0;
        totalScore = 0;
        currentLocation = Locations.SweetHome;*/

    }
    // Start is called before the first frame update
    private FSMStates[] states;
    private FSMStates currentState;
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

    public void ChangeState(StudentStates newState)
    {
        if (states[(int)newState] == null) return;
        if(currentState != null)
        {
            currentState.Exit(this);
        }
        currentState = states[(int)newState];
        currentState.Enter(this);
    }
}
