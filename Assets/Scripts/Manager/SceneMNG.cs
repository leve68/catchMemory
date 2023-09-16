using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMNG
{
    public BaseScene CurrentScene { get { return GameObject.FindObjectOfType<BaseScene>(); } } //���� ���� BaseScene������

    string GetSceneName(Define.Scenes type) //type���� ���̸� ��������
    {
        string sceneName = System.Enum.GetName(typeof(Define.Scenes), type);
        return sceneName;
    }

    public Define.Scenes LoadScene(Define.Scenes type) //���� �� �����ϰ� ���ϴ� �� �ҷ�����
    {
        GameMNG.Scene.Clear();

        SceneManager.LoadScene(GetSceneName(type));
        return type;
    }

    public void LoadLoadingScene(Define.Scenes type)//���� �� �����ϰ� �ε� �� �ҷ�����
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
