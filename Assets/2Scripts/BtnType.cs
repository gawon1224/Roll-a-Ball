using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnType : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public BTNType currentType;
    public Transform buttonScale;
    Vector3 defaultScale;   // 버튼의 초기 크기를 담을 vector3변수 생성
    public CanvasGroup mainGroup;
    public CanvasGroup optionGroup;
    public GameManagerLogic manager;
    private void Start()
    {
        // defualtScale을 buttonScale로 초기화해줌
        defaultScale = buttonScale.localScale;

        if(!PlayerPrefs.HasKey("isSound"))
        {
            PlayerPrefs.SetInt("isSound", 0);
            Load();
        }
        else
        {
            Load();
        }

        AudioListener.pause = isSound;
    }

    bool isSound;
    public void OnBtnClick()
    {
        // 버튼 UI의 OnClick 이벤트에 연결해주는 메소드 정의
        // 조건이 currentType인 switch.case문
        switch(currentType)
        {
            case BTNType.New:   // currentType이 New이면
                SceneLoader.LoadSceneHandle("SampleScene1_0", 0);
                break;
           // case BTNType.Continue:
             //   SceneLoader.LoadSceneHandle("SampleScene1_" + manager.stage.ToString(), 1);
               // break;
            case BTNType.Option:
                CanvasGroupOn(optionGroup);
                CanvasGroupOff(mainGroup);
                break;
            case BTNType.Sound:
                if(isSound)
                {
                    Debug.Log("사운드OFF");
                    AudioListener.pause = true;
                }
                else
                {
                    Debug.Log("사운드ON");
                    AudioListener.pause = false;
                }
                isSound = !isSound;
                Save();

                break;
            case BTNType.Back:
                CanvasGroupOn(mainGroup);
                CanvasGroupOff(optionGroup);
                break;
            case BTNType.Quit:
                Application.Quit();
                Debug.Log("앱종료");
                break;

        }
    }

    private void Load()
    {
        isSound = PlayerPrefs.GetInt("isSound") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("isSound", isSound ? 1 : 0);
    }

    public void CanvasGroupOn(CanvasGroup cg)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }
    public void CanvasGroupOff(CanvasGroup cg)
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // 마우스 커서가 버튼 위에 있으면 버튼이 원래 크기의 1.2배로 커지게 하는 메소드 정의
        buttonScale.localScale = defaultScale*1.2f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // 마우스 커서가 오브젝트를 벗어나면 원래 크기로 돌아오는 메소드 정의
        buttonScale.localScale = defaultScale;
    }
}
