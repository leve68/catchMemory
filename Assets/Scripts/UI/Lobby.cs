using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Lobby : UI_Scene
{
    public static bool firstGame;
    private SaveData unlockData; //저장데이터
    private List<int> unlockedScenes;
    enum GameObjects    
    {
        panel,
    }
    private void Start()
    {
        Init();
    }
    public override void Init()
    {
        base.Init();

        Bind<GameObject>(typeof(GameObjects));

        Caching.ClearCache();
        unlockData = GameMNG.Data.GetSaveData();
        foreach (GameData data in unlockData.saveDatas)
        {
            unlockedScenes = data.unlocked_scenes;
        }

        if (unlockedScenes.Contains(0))
        {
            firstGame = true;
        }
        else firstGame = false;

        if (firstGame)
        {
            Get<GameObject>((int)GameObjects.panel).gameObject.EventBind(LoadCutScene1);
        }
        else Get<GameObject>((int)GameObjects.panel).gameObject.EventBind(LoadSelectScene);
    }
    public void LoadCutScene1(PointerEventData eventData)
    {
        GameMNG.Scene.LoadCutScene(Define.Scenes.CutScene, 0); //CutScene1 완성안돼서 StageSelect로 보냄
    }

    public void LoadSelectScene(PointerEventData eventData)
    {
        GameMNG.Scene.LoadLoadingScene(Define.Scenes.StageSelect);
    }
}
