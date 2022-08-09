using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnType : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public BTNType currentType;
    public Transform buttonScale;
    Vector3 defaultScale;   // ��ư�� �ʱ� ũ�⸦ ���� vector3���� ����
    public CanvasGroup mainGroup;
    public CanvasGroup optionGroup;
    public GameManagerLogic manager;
    private void Start()
    {
        // defualtScale�� buttonScale�� �ʱ�ȭ����
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
        // ��ư UI�� OnClick �̺�Ʈ�� �������ִ� �޼ҵ� ����
        // ������ currentType�� switch.case��
        switch(currentType)
        {
            case BTNType.New:   // currentType�� New�̸�
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
                    Debug.Log("����OFF");
                    AudioListener.pause = true;
                }
                else
                {
                    Debug.Log("����ON");
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
                Debug.Log("������");
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
        // ���콺 Ŀ���� ��ư ���� ������ ��ư�� ���� ũ���� 1.2��� Ŀ���� �ϴ� �޼ҵ� ����
        buttonScale.localScale = defaultScale*1.2f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // ���콺 Ŀ���� ������Ʈ�� ����� ���� ũ��� ���ƿ��� �޼ҵ� ����
        buttonScale.localScale = defaultScale;
    }
}
