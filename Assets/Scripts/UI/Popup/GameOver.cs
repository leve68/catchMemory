using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameOver : UI_Popup
{
    public Define.Scenes CurrentStage;
    enum Buttons
    {
        resetStage,
        selectStage,
    }
    private void Start()
    {
        Init();
    }
    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));

        Get<Button>((int)Buttons.resetStage).gameObject.EventBind(StartNewGame);
        Get<Button>((int)Buttons.selectStage).gameObject.EventBind(ShowStageSelectScene);
    }
    public void ShowStageSelectScene(PointerEventData eventData)
    {
        GameMNG.UI.CloseAllPopupUI();
        GameMNG.Scene.LoadLoadingScene(Define.Scenes.StageSelect);
    }
    public void StartNewGame(PointerEventData eventData)
    {
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
