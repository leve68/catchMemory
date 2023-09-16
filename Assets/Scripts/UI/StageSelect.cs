using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StageSelect : UI_Scene
{
    public static bool fromSelectUI;
    private SaveData unlockData; //저장데이터
    private List<int> unlockedScenes;
    private List<int> unlockedStages;
    enum Buttons
    {
        cutScene0,
        cutScene1,
        cutScene2,
        cutScene3,
        cutScene4,
        cutScene5,
        cutScene6,
        stage1,
        stage2,
        stage3,
        stage4,
        stage5,
    }
    private void Start()
    {
        Init();
    }
    public override void Init()
    {
        base.Init();

        Caching.ClearCache();
        unlockData = GameMNG.Data.GetSaveData();
        foreach (GameData data in unlockData.saveDatas)
        {
            unlockedScenes = data.unlocked_scenes;
            unlockedStages = data.unlocked_stages;
        }

        Bind<Button>(typeof(Buttons));

        Get<Button>((int)Buttons.cutScene0).gameObject.EventBind(LoadCutScene0);
        Get<Button>((int)Buttons.cutScene1).gameObject.EventBind(LoadCutScene1);
        Get<Button>((int)Buttons.cutScene2).gameObject.EventBind(LoadCutScene2);
        Get<Button>((int)Buttons.cutScene3).gameObject.EventBind(LoadCutScene3);
        Get<Button>((int)Buttons.cutScene4).gameObject.EventBind(LoadCutScene4);
        Get<Button>((int)Buttons.cutScene5).gameObject.EventBind(LoadCutScene5);
        Get<Button>((int)Buttons.cutScene6).gameObject.EventBind(LoadCutScene6);

        Get<Button>((int)Buttons.stage1).gameObject.EventBind(LoadStage1);
        Get<Button>((int)Buttons.stage2).gameObject.EventBind(LoadStage2);
        Get<Button>((int)Buttons.stage3).gameObject.EventBind(LoadStage3);
        Get<Button>((int)Buttons.stage4).gameObject.EventBind(LoadStage4);
        Get<Button>((int)Buttons.stage5).gameObject.EventBind(LoadStage5);

        for (int i = 1; i <= 5; i++) // 스테이지 개수에 따라 범위 수정
        {
            if (!unlockedStages.Contains(i))
            {
                Sprite lockedImage = GameMNG.Resource.Load<Sprite>($"Image/UI/StageSelect/LockedStage{i}");
                Get<Button>((int)Buttons.stage1 + i - 1).GetComponent<Image>().sprite = lockedImage; // 잠긴 이미지를 대입
                Get<Button>((int)Buttons.stage1 + i - 1).gameObject.GetComponent<UI_EventHandler>().enabled = false;
            }
            else
            {
                Sprite lockedImage = GameMNG.Resource.Load<Sprite>($"Image/UI/StageSelect/UnlockedStage{i}");
                Get<Button>((int)Buttons.stage1 + i - 1).GetComponent<Image>().sprite = lockedImage; 
            }
        }
        for (int i = 0; i <= 6; i++) // 컷씬 개수에 따라 범위 수정
        {
            if (!unlockedScenes.Contains(i))
            {
                Sprite lockedScene = GameMNG.Resource.Load<Sprite>("Image/UI/StageSelect/LockedScene");
                Get<Button>((int)Buttons.cutScene0 + i).GetComponent<Image>().sprite = lockedScene; // 잠긴 이미지를 대입
                Get<Button>((int)Buttons.cutScene0 + i).gameObject.GetComponent<UI_EventHandler>().enabled = false;
            }
            else
            {
                Sprite lockedScene = GameMNG.Resource.Load<Sprite>($"Image/UI/StageSelect/UnlockedScene{i+1}");
                Get<Button>((int)Buttons.cutScene0 + i).GetComponent<Image>().sprite = lockedScene;
            }
        }
    }

    #region 컷씬 로딩 코드
    public void LoadCutScene0(PointerEventData eventData)
    {
        fromSelectUI = true;
        GameMNG.Sound.Play("Effect/11_GameLoad");
        GameMNG.Scene.LoadCutScene(Define.Scenes.CutScene, 0);
    }
    public void LoadCutScene1(PointerEventData eventData)
    {
        fromSelectUI = true;
        GameMNG.Sound.Play("Effect/11_GameLoad");
        GameMNG.Scene.LoadCutScene(Define.Scenes.CutScene, 1);
    }
    public void LoadCutScene2(PointerEventData eventData)
    {
        fromSelectUI = true;
        GameMNG.Sound.Play("Effect/11_GameLoad");
        GameMNG.Scene.LoadCutScene(Define.Scenes.CutScene, 2);
    }
    public void LoadCutScene3(PointerEventData eventData)
    {
        fromSelectUI = true;
        GameMNG.Sound.Play("Effect/11_GameLoad");
        GameMNG.Scene.LoadCutScene(Define.Scenes.CutScene, 3);
    }
    public void LoadCutScene4(PointerEventData eventData)
    {
        fromSelectUI = true;
        GameMNG.Sound.Play("Effect/11_GameLoad");
        GameMNG.Scene.LoadCutScene(Define.Scenes.CutScene, 4);
    }
    public void LoadCutScene5(PointerEventData eventData)
    {
        fromSelectUI = true;
        GameMNG.Sound.Play("Effect/11_GameLoad");
        GameMNG.Scene.LoadCutScene(Define.Scenes.CutScene, 5);
    }
    public void LoadCutScene6(PointerEventData eventData)
    {
        fromSelectUI = true;
        GameMNG.Sound.Play("Effect/11_GameLoad");
        GameMNG.Scene.LoadCutScene(Define.Scenes.CutScene, 6);
    }
    #endregion
    #region 스테이지 로딩 코드
    public void LoadStage1(PointerEventData eventData)
    {
        fromSelectUI = false;
        GameMNG.Sound.Play("Effect/11_GameLoad");
        GameMNG.Scene.LoadLoadingScene(Define.Scenes.Stage1);
    }
    public void LoadStage2(PointerEventData eventData)
    {
        fromSelectUI = false;
        GameMNG.Sound.Play("Effect/11_GameLoad");
        GameMNG.Scene.LoadLoadingScene(Define.Scenes.Stage2);
    }
    public void LoadStage3(PointerEventData eventData)
    {
        fromSelectUI = false;
        GameMNG.Sound.Play("Effect/11_GameLoad");
        GameMNG.Scene.LoadLoadingScene(Define.Scenes.Stage3);
    }
    public void LoadStage4(PointerEventData eventData)
    {
        fromSelectUI = false;
        GameMNG.Sound.Play("Effect/11_GameLoad");
        GameMNG.Scene.LoadLoadingScene(Define.Scenes.Stage4);
    }
    public void LoadStage5(PointerEventData eventData)
    {
        fromSelectUI = false;
        GameMNG.Sound.Play("Effect/11_GameLoad");
        GameMNG.Scene.LoadLoadingScene(Define.Scenes.Stage5);
    }
    #endregion
}
