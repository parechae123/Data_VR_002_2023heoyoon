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
            Debug.Log("�÷��̾� ���");
            yield return null;
        }
    }
    IEnumerator Run()
    {
        while (true)
        {
            anim.SetTrigger(plrStates.ToString());
            Debug.Log("�÷��̾� ��");
            yield return null;
        }
    }
    IEnumerator Attack()
    {
        Debug.Log("�÷��̾� ����");
        yield return new WaitForEndOfFrame();
        anim.SetTrigger(plrStates.ToString());
        isAttackAnimOver();
        yield return new WaitForEndOfFrame();
        float animTime = anim.GetCurrentAnimatorStateInfo(0).length;//�̷��� �ϸ� �ش� �ִϸ��̼� �ð��� ����
        Debug.Log(animTime);
        while(!isAttackAnimOver())
        {
            yield return new WaitForEndOfFrame();
            /*if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("2Ÿ");
                break;
            }*/
            Debug.Log(animTime);
        }
        Debug.Log("�ִ� ��");
/*        stateUpdate(PlrStates.Idle);*/
    }
    IEnumerator Garding()
    {
        while (true)
        {
            anim.SetTrigger(plrStates.ToString());
            Debug.Log("�÷��̾� ����");
            yield return null;
        }
    }

}



