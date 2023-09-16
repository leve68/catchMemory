using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExitAnimation : BaseScene
{
    private SaveData unlockData;
    private CutScene_Anim cutscene;

    protected override void Init() // 상속 받은 Awake() 안에서 실행됨
    {
        base.Init();

        SceneType = Define.Scenes.CutScene;
    }

    public override void Clear()
    {
        GameMNG.Sound.Clear();
    }
    void AnimatorExit()
    {
        if (CutScene_Anim.SceneNum == 0)
        {
            SaveSceneData(CutScene_Anim.SceneNum);
            if(StageSelect.fromSelectUI == true)
            {
                GameMNG.Scene.LoadLoadingScene(Define.Scenes.StageSelect);
            }
            else GameMNG.Scene.LoadLoadingScene(Define.Scenes.Stage1);
        }
        if (CutScene_Anim.SceneNum == 1)
        {
            SaveSceneData(CutScene_Anim.SceneNum);
            if (StageSelect.fromSelectUI == true)
            {
                GameMNG.Scene.LoadLoadingScene(Define.Scenes.StageSelect);
            }
            else GameMNG.Scene.LoadLoadingScene(Define.Scenes.Stage2);
        }
        if (CutScene_Anim.SceneNum == 2)
        {
            SaveSceneData(CutScene_Anim.SceneNum);
            if (StageSelect.fromSelectUI == true)
            {
                GameMNG.Scene.LoadLoadingScene(Define.Scenes.StageSelect);
            }
            else GameMNG.Scene.LoadLoadingScene(Define.Scenes.Stage3);
        }
        if (CutScene_Anim.SceneNum == 3)
        {
            SaveSceneData(CutScene_Anim.SceneNum);
            if (StageSelect.fromSelectUI == true)
            {
                GameMNG.Scene.LoadLoadingScene(Define.Scenes.StageSelect);
            }
            else GameMNG.Scene.LoadLoadingScene(Define.Scenes.Stage4);
        }
        if (CutScene_Anim.SceneNum == 4)
        {
            SaveSceneData(CutScene_Anim.SceneNum);
            if (StageSelect.fromSelectUI == true)
            {
                GameMNG.Scene.LoadLoadingScene(Define.Scenes.StageSelect);
            }
            else GameMNG.Scene.LoadLoadingScene(Define.Scenes.Stage5);
        }
        if (CutScene_Anim.SceneNum == 6)
        {
            SaveSceneData(CutScene_Anim.SceneNum);
            if (StageSelect.fromSelectUI == true)
            {
                GameMNG.Scene.LoadLoadingScene(Define.Scenes.StageSelect);
            }
            else GameMNG.Scene.LoadLoadingScene(Define.Scenes.Lobby);
        }
        if (CutScene_Anim.SceneNum == 5)
        {
            SaveSceneData(CutScene_Anim.SceneNum);
            if (StageSelect.fromSelectUI == true)
            {
                GameMNG.Scene.LoadLoadingScene(Define.Scenes.StageSelect);
            }
            else GameMNG.Scene.LoadCutScene(Define.Scenes.CutScene, 6); 
        }
    }
    public void SaveSceneData(int currScene)
    {
        unlockData = GameMNG.Data.GetSaveData();
        foreach (GameData data in unlockData.saveDatas) // GameData의 데이터 교체
        {
            if (!data.unlocked_scenes.Contains(currScene)) //1을 가지고 있지 않다면
            {
                data.unlocked_scenes.Add(currScene);
                GameMNG.Data.SaveJson<SaveData, int, GameData>("Save", unlockData); //json에 저장
            }
        }
    }
}
