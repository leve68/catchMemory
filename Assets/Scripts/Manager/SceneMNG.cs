using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMNG
{
    public BaseScene CurrentScene { get { return GameObject.FindObjectOfType<BaseScene>(); } } //현재 씬의 BaseScene리턴함

    string GetSceneName(Define.Scenes type) //type으로 씬이름 가져오기
    {
        string sceneName = System.Enum.GetName(typeof(Define.Scenes), type);
        return sceneName;
    }

    public Define.Scenes LoadScene(Define.Scenes type) //현재 씬 삭제하고 원하는 씬 불러오기
    {
        GameMNG.Scene.Clear();

        SceneManager.LoadScene(GetSceneName(type));
        return type;
    }

    public void LoadLoadingScene(Define.Scenes type)//현재 씬 삭제하고 로딩 씬 불러오기
    {
        GameMNG.Scene.Clear();
        GameMNG.Sound.Clear();

        LoadingScene.destScene = GetSceneName(type);
        SceneManager.LoadScene("Loading");
    }
    public void Clear()
    {
        CurrentScene.Clear();
    }
    public void LoadCutScene(Define.Scenes type, int sceneNum)
    {
        GameMNG.Scene.Clear();
        CutScene_Anim.SceneNum = sceneNum;

        LoadingScene.destScene = GetSceneName(type);
        SceneManager.LoadScene("Loading");
    }
}
