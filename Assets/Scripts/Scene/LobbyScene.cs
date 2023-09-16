using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LobbyScene : BaseScene
{
    protected override void Init() // 상속 받은 Awake() 안에서 실행됨
    {
        base.Init(); 

        SceneType = Define.Scenes.Lobby; 

        GameMNG.UI.ShowSceneUI<Lobby>("Lobby"); // Lobby UI 생성

        GameMNG.Sound.Play("BGM/캐치메모리_st1", Define.Sound.Bgm);
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
