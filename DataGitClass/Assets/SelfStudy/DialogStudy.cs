using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogStudy : MonoBehaviour
{
   [SerializeField]private Dialogthings[] dialogInfoIndex;
    public Text charactorName;
    public Text charactorScript;
    public int diaStackIndex = 0;
    public bool isCoroutineEnd;
    // Start is called before the first frame update
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (charactorScript.gameObject.activeSelf == true)
            {
                if (diaStackIndex < dialogInfoIndex.Length)
                {
                    if (isCoroutineEnd)
                    {
                        StartCoroutine(DialogOutput(diaStackIndex));
                    }
                    else
                    {
                        Debug.Log("Å¸ÀÌÇÎ Äµ½½");
                        StopCoroutine("DialogOutput");
                        isCoroutineEnd = true;
                    }
                }
                else
                {
                    charactorName.gameObject.SetActive(false);
                    charactorScript.gameObject.SetActive(false);
                }
            }

        }
    }
    [System.Serializable]
    public struct Dialogthings
    {
        public int index;
        public string charactorName;
        public string script;
    }
    IEnumerator DialogOutput(int a)
    {
        yield return new WaitUntil(() => isCoroutineEnd == true);
        diaStackIndex++;
        int indx = dialogInfoIndex[a].script.Length;
        charactorName.text = dialogInfoIndex[a].charactorName;
        Debug.Log(dialogInfoIndex.Length);
        if (a < dialogInfoIndex.Length)
        {
            isCoroutineEnd = false;
            for (int i = 0; i <= dialogInfoIndex[a].script.Length; i++)
            {
                charactorScript.text = dialogInfoIndex[a].script.Substring(0, i);
                yield return new WaitForSeconds(0.1f);
                if(isCoroutineEnd == true)
                {
                    charactorScript.text = dialogInfoIndex[diaStackIndex-1].script;
                    break;
                }
            }
            isCoroutineEnd = true;
        }
    }
}
