using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define //UI에서 관리할 것들을 enum으로 정리
{
    public enum UIEvent
    {
        ButtonDown,
        Drag,
        ButtonUp,
    }
    public enum Scenes
    {
        Lobby,
        Stage1,
        Stage2,
        Stage3,
        Stage4,
        Stage5,
        CutScene,
        StageSelect,
        GameOver,
        Loading,
        Ending,
    }
    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount,
    }
}