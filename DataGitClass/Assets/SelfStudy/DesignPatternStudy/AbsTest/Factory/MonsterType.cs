using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonsterType
{
    public abstract void MonsterRace();
    //가독성을 위해서 상속시키는 경우 굳이 상속 추상클래스 말고
    //일반 public class 안에
    //virtual로 함수작성하면 상속받는 클래스들에서도 사용이 가능하다
}
