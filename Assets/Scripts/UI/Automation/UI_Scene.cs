using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Scene : UI_Base //Scene�� �⺻�� �Ǵ� ���� UI -> �ı� �Ұ���
{
    public override void Init()
    {
        GameMNG.UI.SetCanvas(gameObject, false);
    }
}
