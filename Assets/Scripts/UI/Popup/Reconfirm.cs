using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Reconfirm : UI_Popup //����Ǿ����ϴ� Ȯ��
{
    enum Buttons
    {
        close,
        yes,
    }
    enum Texts
    {
        checkText,
    }
    private void Start()
    {
        Init();
    }
    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));

        Get<Text>((int)Texts.checkText).text = "����Ǿ����ϴ�";
        Get<Button>((int)Buttons.close).gameObject.EventBind(ClosePopup);
        Get<Button>((int)Buttons.yes).gameObject.EventBind(CloseAllPopup);
    }
    public void ClosePopup(PointerEventData eventData)
    {
        GameMNG.UI.ClosePopupUI();
    }
    public void CloseAllPopup(PointerEventData eventData)
    {
        GameMNG.UI.CloseAllPopupUI();
        //���� Data����
    }
}
public class ConfirmEndStage : UI_Popup
{
    enum Buttons
    {
        close,
        yes,
        no,
    }
    enum Texts
    {
        checkText,
    }
    private void Start()
    {
        Init();
    }
    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));

        Get<Text>((int)Texts.checkText).text = "���������� ��ġ�ðڽ��ϱ�?";
        Get<Button>((int)Buttons.close).gameObject.EventBind(ClosePopup);
        Get<Button>((int)Buttons.no).gameObject.EventBind(ClosePopup);
        Get<Button>((int)Buttons.yes).gameObject.EventBind(LoadSelectScene);
    }
    public void ClosePopup(PointerEventData eventData)
    {
        GameMNG.Sound.Play("Effect/01_Option");
        GameMNG.UI.ClosePopupUI();
        Time.timeScale = 1;
    }
    public void LoadSelectScene(PointerEventData eventData)
    {
        GameMNG.Sound.Play("Effect/01_Option");
        GameMNG.UI.CloseAllPopupUI();
        GameMNG.Scene.LoadLoadingScene(Define.Scenes.StageSelect);
        Time.timeScale = 1;
    }
}
public class ConfirmNewStart : UI_Popup
{
    public Define.Scenes CurrentStage;
    enum Buttons
    {
        close,
        yes,
        no,
    }
    enum Texts
    {
        checkText,
    }
    private void Start()
    {
        Init();
    }
    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));

        Get<Text>((int)Texts.checkText).text = "�ش� �������� ó������ ���ư��ðڽ��ϱ�?";
        Get<Button>((int)Buttons.close).gameObject.EventBind(ClosePopup);
        Get<Button>((int)Buttons.no).gameObject.EventBind(ClosePopup);
        Get<Button>((int)Buttons.yes).gameObject.EventBind(StartNewGame);

        
    }
    public void ClosePopup(PointerEventData eventData)
    {
        GameMNG.Sound.Play("Effect/01_Option");
        GameMNG.UI.ClosePopupUI();
    }
    public void StartNewGame(PointerEventData eventData)
    {
        GameMNG.Sound.Play("Effect/01_Option");
        GameMNG.UI.CloseAllPopupUI();
        GameObject SceneMNG = GameObject.FindWithTag("Scene");
        Time.timeScale = 1;
        if (SceneMNG.GetComponent<StageScene1>() != null)
        {
            GameMNG.Scene.LoadLoadingScene(Define.Scenes.Stage1);
        }
        if (SceneMNG.GetComponent<StageScene2>() != null)
        {
            GameMNG.Scene.LoadLoadingScene(Define.Scenes.Stage2);
        }
        if (SceneMNG.GetComponent<StageScene3>() != null)
        {
            GameMNG.Scene.LoadLoadingScene(Define.Scenes.Stage3);
        }
        if (SceneMNG.GetComponent<StageScene4>() != null)
        {
            GameMNG.Scene.LoadLoadingScene(Define.Scenes.Stage4);
        }
        if (SceneMNG.GetComponent<StageScene5>() != null)
        {
            GameMNG.Scene.LoadLoadingScene(Define.Scenes.Stage5);
        }
    }
}