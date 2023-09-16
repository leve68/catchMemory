using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectScene : BaseScene
{

    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scenes.StageSelect;

        GameMNG.UI.ShowSceneUI<StageSelect>();
    }

    public override void Clear() 
    {

    }
}
