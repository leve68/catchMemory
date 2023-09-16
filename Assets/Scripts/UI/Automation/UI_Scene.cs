using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Scene : UI_Base //Scene의 기본이 되는 고정 UI -> 파괴 불가능
{
    public override void Init()
    {
        GameMNG.UI.SetCanvas(gameObject, false);
    }
}
