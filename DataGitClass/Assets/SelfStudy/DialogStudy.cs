using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogStudy : MonoBehaviour
{
   [SerializeField]private Dialogthings[] dialogInfoIndex;
    public Text charactorName;
    public Text charactorScript;
    // Start is called before the first frame update

    private void Start()
    {
        StartCoroutine(DialogOutput(0));
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
        charactorName.text = dialogInfoIndex[a].charactorName;
        for (int i = 0; i < dialogInfoIndex[a].script.Length; i++)
        {
            yield return new WaitForSeconds(0.1f);
            int indx = dialogInfoIndex[a].script.Length;
            charactorScript.text = dialogInfoIndex[a].script.Substring(i);
            //괄호 안에 있는 
        }

    }
}
