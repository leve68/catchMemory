using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define //UI���� ������ �͵��� enum���� ����
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