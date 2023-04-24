using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    static GameManager GM;

    public static GameManager instance()
    {
        return GM;
    }
    void Start()
    {
        if(GM == null)
        {
            GM = this;
            DontDestroyOnLoad(this.gameObject);
            //gm�� �������� �̰� GM���� ����ƽ�� �־��ְ�
        }
        else
        {
            if(this != GM)
            {
                //GM�� �ִµ� �̰� GM�� �ƴҽ� �������ش�
                Destroy(this.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene("DialogTest");
        }
    }
}
