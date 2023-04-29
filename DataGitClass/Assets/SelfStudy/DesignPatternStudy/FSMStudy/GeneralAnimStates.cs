using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerState { Idle = 0, Walk,Run,Attack}
public class GeneralAnimStates : MonoBehaviour
{
    private PlayerState playerStates;
    // Start is called before the first frame update
    void Awake()
    {
        ChangeState(PlayerState.Idle);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1")) ChangeState(PlayerState.Idle);
        if (Input.GetKeyDown("2")) ChangeState(PlayerState.Walk);
        if (Input.GetKeyDown("3")) ChangeState(PlayerState.Run);
        if (Input.GetKeyDown("4")) ChangeState(PlayerState.Attack);//���⼭ �Է��� ������
    }

    private void ChangeState(PlayerState newState)
    {
        StopCoroutine(playerStates.ToString());//���� ������Ʈ���� String���� ��ȯ�Ͽ� ���� �̸��� ���� �ڷ�ƾ�� ���������ش�.
        playerStates = newState;//���⼭�� �Ű������� ���ι��� ������Ʈ���� �������ְ�
        StartCoroutine(playerStates.ToString());//���⼭�� State�� String���� ��ȯ�Ͽ� �ش� �ڷ�ƾ�� �������ش�
    }
    private IEnumerator Idle()
    {
        Debug.Log("�÷��̾ Idle���·� �����մϴ�");
        while (true)
        {
            Debug.Log("�÷��̾� Idle����");
            yield return null;
        }
    }
    private IEnumerator Walk()
    {
        Debug.Log("�÷��̾ Walk���·� �����մϴ�");
        while (true)
        {
            Debug.Log("�÷��̾� Walk����");
            yield return null;
        }
    }
    private IEnumerator Run()
    {
        Debug.Log("�÷��̾ Run���·� �����մϴ�");
        while (true)
        {
            Debug.Log("�÷��̾� Run����");
            yield return null;
        }
    }
    private IEnumerator Attack()
    {
        Debug.Log("�÷��̾ Attack���·� �����մϴ�");
        while (true)
        {
            Debug.Log("�÷��̾� Attack����");
            yield return null;
        }
    }
}
