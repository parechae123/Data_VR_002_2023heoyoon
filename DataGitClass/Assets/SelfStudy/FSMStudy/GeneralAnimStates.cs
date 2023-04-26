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
        if (Input.GetKeyDown("4")) ChangeState(PlayerState.Attack);//여기서 입력을 받으면
    }

    private void ChangeState(PlayerState newState)
    {
        StopCoroutine(playerStates.ToString());//현재 스테이트값을 String으로 변환하여 같은 이름을 가진 코루틴을 중지시켜준다.
        playerStates = newState;//여기서는 매개변수로 새로받은 스테이트값을 저장해주고
        StartCoroutine(playerStates.ToString());//여기서도 State를 String으로 변환하여 해당 코루틴을 시작해준다
    }
    private IEnumerator Idle()
    {
        Debug.Log("플레이어가 Idle상태로 진입합니다");
        while (true)
        {
            Debug.Log("플레이어 Idle유지");
            yield return null;
        }
    }
    private IEnumerator Walk()
    {
        Debug.Log("플레이어가 Walk상태로 진입합니다");
        while (true)
        {
            Debug.Log("플레이어 Walk유지");
            yield return null;
        }
    }
    private IEnumerator Run()
    {
        Debug.Log("플레이어가 Run상태로 진입합니다");
        while (true)
        {
            Debug.Log("플레이어 Run유지");
            yield return null;
        }
    }
    private IEnumerator Attack()
    {
        Debug.Log("플레이어가 Attack상태로 진입합니다");
        while (true)
        {
            Debug.Log("플레이어 Attack유지");
            yield return null;
        }
    }
}
