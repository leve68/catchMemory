using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LobbyScene : BaseScene
{
    protected override void Init() // ��� ���� Awake() �ȿ��� �����
    {
        base.Init(); 

        SceneType = Define.Scenes.Lobby; 

        GameMNG.UI.ShowSceneUI<Lobby>("Lobby"); // Lobby UI ����

        GameMNG.Sound.Play("BGM/ĳġ�޸�_st1", Define.Sound.Bgm);
    }

    public override void Clear()
    {
        GameMNG.Sound.Clear();
    }

    public Define.Scenes GetSceneType()
    {
        return SceneType;
    }
}
