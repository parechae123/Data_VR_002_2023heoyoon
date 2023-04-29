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
    protected virtual void stateUpdate(PlrStates newState)
    {
        StopCoroutine(plrStates.ToString());
        plrStates = newState;
        StartCoroutine(plrStates.ToString());
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
        anim.SetTrigger(plrStates.ToString());
        while (true)
        {
            Debug.Log("플레이어 대기");
            yield return null;
        }
    }
    IEnumerator Run()
    {
        while (true)
        {
            anim.SetTrigger(plrStates.ToString());
            Debug.Log("플레이어 런");
            yield return null;
        }
    }
    IEnumerator Attack()
    {
        Debug.Log("플레이어 어택");
        yield return new WaitForEndOfFrame();
        anim.SetTrigger(plrStates.ToString());
        isAttackAnimOver();
        yield return new WaitForEndOfFrame();
        float animTime = anim.GetCurrentAnimatorStateInfo(0).length;//이렇게 하면 해당 애니메이션 시간이 나옴
        Debug.Log(animTime);
        while(!isAttackAnimOver())
        {
            yield return new WaitForEndOfFrame();
            /*if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("2타");
                break;
            }*/
            Debug.Log(animTime);
        }
        Debug.Log("애님 끝");
/*        stateUpdate(PlrStates.Idle);*/
    }
    IEnumerator Garding()
    {
        while (true)
        {
            anim.SetTrigger(plrStates.ToString());
            Debug.Log("플레이어 막기");
            yield return null;
        }
    }

}



