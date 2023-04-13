using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               //UI를 컨트롤 할 것이라서 추가
using System;                       //array 수정 기능을 사용하기 위해 추가

public class DialogSystem : MonoBehaviour
{
    [SerializeField]
    private SpeakerUI[] speakers;               //대화에 참여하는 캐릭터들의 UI 배열
    [SerializeField]
    private DialogData[] dialogs;               //현재 분기의 대사 목록 배열
    [SerializeField]
    private bool DialogInit = true;             //자동 시작 여부
    [SerializeField]
    private bool dialogsDB = false;             //DB를 통해 읽는것 설정

    public int currentDialogIndex = -1;         //현재 대사 순번
    public int currentSpeakerIndex = 0;         //현재 말을 하는 화자의 Speakers 배열 순번
    public float typingSpeed = 0.1f;            //텍스트 타이핑 효과의 재생속도
    public bool isTypingEffect = false;         //텍스트 타이핑 효과가 재생중인지 판단.

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //함수를 통해 UI가 보여지거나 안보여지게 설정
    private void SetActiveObjects(SpeakerUI speaker, bool visible)
    {
        speaker.imageDialog.gameObject.SetActive(visible);
        speaker.textName.gameObject.SetActive(visible);
        speaker.textDialogue.gameObject.SetActive(visible);
        //화살표 대사가 종료되었을 때만 활성화 되기 때문에
        speaker.objectArrow.SetActive(false);

        Color color = speaker.imgCharacter.color;
        if (visible)
        {
            color.a = 1;
        }
        else
        {
            color.a = 0.2f;
        }
        speaker.imgCharacter.color = color;
    }

    private void SetAllClose()
    {
        for(int i =0; i <speakers.Length; i++)
        {
            SetActiveObjects(speakers[i], false);
        }
    }

    private void SetNextDialog(int currentIndex)
    {
        SetAllClose();
        currentDialogIndex = currentIndex;              //다음 대사를 진행하도록
        currentSpeakerIndex = dialogs[currentDialogIndex].speakerUIindex;   //현재 화자 순번 설정
        SetActiveObjects(speakers[currentSpeakerIndex], true);             //현재 화자의 대화 관련 오브젝트 활성화
        speakers[currentSpeakerIndex].textName.text = dialogs[currentDialogIndex].name; //현재 화자의 이름 텍스트 설정
        StartCoroutine("OnTypingText");
    }

    private IEnumerator OnTypingText()
    {
        int index = 0;
        isTypingEffect = true;
        if(dialogs[currentDialogIndex].characterPath != "None")
        {
            speakers[currentSpeakerIndex].imgCharacter.sprite = Resources.Load<Sprite>(dialogs[currentDialogIndex].characterPath);
        }
        while (index < dialogs[currentDialogIndex].dialoue.Length + 1)
        {
            speakers[currentSpeakerIndex].textDialogue.text = dialogs[currentDialogIndex].dialoue.Substring(0, index);
            index++;
            yield return new WaitForSeconds(typingSpeed);
            
        }
        isTypingEffect = false;
        speakers[currentSpeakerIndex].objectArrow.SetActive(true);
    }
    public bool UpdateDialog(int currentIndex,bool InitType)
    {
        //대사 분기가 1회만 호출
        if(DialogInit == true&&InitType == true)
        {
            SetAllClose();
            SetNextDialog(currentIndex);
            DialogInit = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if(isTypingEffect == true)
            {
                isTypingEffect = false;
                StopCoroutine("OnTypingText"); //타이핑 효과를 중지하고,현재 대사 전체를 출력한다
                speakers[currentIndex].textDialogue.text = dialogs[currentDialogIndex].dialoue;
                //대사가 완료되었을 때 커서
                speakers[currentSpeakerIndex].objectArrow.SetActive(true);

                return false;
            }
            if(dialogs[currentDialogIndex].nextindex != -100)
            {
                SetNextDialog(dialogs[currentDialogIndex].nextindex);
            }
            else
            {
                SetAllClose();
                DialogInit = true;
                return true;
            }
        }
        return false;
    }

    private void Awake()
    {
        SetAllClose();
    }

    [System.Serializable]
    public struct SpeakerUI
    {
        public Image imgCharacter;          //캐릭터 이미지
        public Image imageDialog;           //대화창 ImageUI
        public Text textName;               //현재 대사중인 캐릭터 이름 출력 TextUI
        public Text textDialogue;           //guswo eotk cnffur Text UI
        public GameObject objectArrow;       //대사가 완료되었을 때 출력하는 커서 오브젝트
    }
    [System.Serializable]
    public struct DialogData
    {
        public int index;                   //대사 번호
        public int speakerUIindex;          //스피커 배열 번호
        public string name;                 //이름
        public string dialoue;              //대사
        public string characterPath;        //캐릭터 이미지 경로
        public int tweenType;               //트윈 번호
        public int nextindex;               //다음 대사
    }
}
