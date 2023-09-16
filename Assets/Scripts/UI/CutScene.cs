using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CutScene : UI_Scene
{
    private int currentCutScene;
    private GameData unlockData;
    enum Buttons
    {
        skip,
    }
    private void Start()
    {
        Init();
    }
    public override void Init()
    {
        base.Init();

        currentCutScene = CutScene_Anim.SceneNum;
        unlockData = GameMNG.Data.DataDict[0]; //저장된 데이터 호출
        List<int> unlockedScenes = unlockData.unlocked_scenes;

        Bind<Button>(typeof(Buttons));

        Get<Button>((int)Buttons.skip).gameObject.EventBind(SkipCutScene);

        if (!unlockedScenes.Contains(currentCutScene))
        {
            Get<Button>((int)Buttons.skip).gameObject.SetActive(false);
        }
    }
    public void SkipCutScene(PointerEventData eventData)
    {

        if (currentCutScene == 0)
        {
            if(StageSelect.fromSelectUI == true)
            {
                GameMNG.Scene.LoadLoadingScene(Define.Scenes.StageSelect);
            }
            else GameMNG.Scene.LoadLoadingScene(Define.Scenes.Stage1);
        }
        if (currentCutScene == 1)
        {
            if (StageSelect.fromSelectUI == true)
            {
                GameMNG.Scene.LoadLoadingScene(Define.Scenes.StageSelect);
            }
            else GameMNG.Scene.LoadLoadingScene(Define.Scenes.Stage2);
        }
        if (currentCutScene == 2)
        {
            if (StageSelect.fromSelectUI == true)
            {
                GameMNG.Scene.LoadLoadingScene(Define.Scenes.StageSelect);
            }
            else GameMNG.Scene.LoadLoadingScene(Define.Scenes.Stage3);
        }
        if (currentCutScene == 3)
        {
            if (StageSelect.fromSelectUI == true)
            {
                GameMNG.Scene.LoadLoadingScene(Define.Scenes.StageSelect);
            }
            else GameMNG.Scene.LoadLoadingScene(Define.Scenes.Stage4);
        }
        if (currentCutScene == 4)
        {
            if (StageSelect.fromSelectUI == true)
            {
                GameMNG.Scene.LoadLoadingScene(Define.Scenes.StageSelect);
            }
            else GameMNG.Scene.LoadLoadingScene(Define.Scenes.Stage5);
        }
        if (currentCutScene == 5)
        {
            if (StageSelect.fromSelectUI == true)
            {
                GameMNG.Scene.LoadLoadingScene(Define.Scenes.StageSelect);
            }
            else GameMNG.Scene.LoadCutScene(Define.Scenes.CutScene, 6);
        }        
        if (currentCutScene == 6)
        {
            if (StageSelect.fromSelectUI == true)
            {
                GameMNG.Scene.LoadLoadingScene(Define.Scenes.StageSelect);
            }
            else GameMNG.Scene.LoadLoadingScene(Define.Scenes.Lobby);
        }
    }
}
