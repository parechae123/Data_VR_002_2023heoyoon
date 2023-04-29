using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public class AnimatorState <T>
{
    public T nowStateToStr { get; set; }
}
public enum PlrStates { Idle=0,Run,Attack,Garding}
public class PlayerAnimTree: MonoBehaviour
{
    protected PlrStates plrStates;
    protected Rigidbody rb;
    AnimatorState<string> state = new AnimatorState<string>();
    protected Animator anim;
    protected int atkCount = 0;
    protected virtual void stateUpdate(PlrStates newState)
    {
        if (isAttackAnimOver())
        {
            StopCoroutine(plrStates.ToString());
            anim.SetBool(plrStates.ToString(), false);
            plrStates = newState;
            StartCoroutine(plrStates.ToString());
        }

    }
    public bool isAttackAnimOver()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    IEnumerator Idle()
    {
        anim.SetBool(plrStates.ToString(), true);
        while (true)
        {
            Debug.Log("플레이어 대기");
            yield return null;
        }
    }
    IEnumerator Run()
    {
        anim.SetBool(plrStates.ToString(), true);
        while (true)
        {
            Debug.Log("플레이어 런");
            yield return null;
        }
    }
    IEnumerator Attack()
    {
        Debug.Log("플레이어 어택");
        yield return new WaitForEndOfFrame();
        Debug.Log(plrStates);
        ++atkCount;
        anim.SetInteger("AttackStats", atkCount);
        anim.SetBool(plrStates.ToString(), true);
        yield return new WaitForEndOfFrame();
        /*float animTime = anim.GetCurrentAnimatorStateInfo(0).length;//이렇게 하면 해당 애니메이션 시간이 나옴*/
        while (!isAttackAnimOver())
        {
            yield return new WaitForEndOfFrame();
            if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8f)
            {
                anim.SetInteger("AttackStats", atkCount);
            }
        }
        Debug.Log("아님 끝");
        atkCount = 0;
        stateUpdate(PlrStates.Idle);
    }
    IEnumerator Garding()
    {
        anim.SetBool(plrStates.ToString(), true);
        while (true)
        {
            Debug.Log("플레이어 막기");
            yield return null;
        }
    }

}



