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
            //gm이 없을때는 이걸 GM으로 스태틱에 넣어주고
        }
        else
        {
            if(this != GM)
            {
                //GM이 있는데 이게 GM이 아닐시 삭제해준다
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
