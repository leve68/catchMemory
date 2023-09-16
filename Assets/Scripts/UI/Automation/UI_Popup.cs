using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UI_Popup : UI_Base
{
    public override void Init() //UI canvas ¼¼ÆÃ
    {
        GameMNG.UI.SetCanvas(gameObject, true);
    }

    public virtual void ClosedPopupUI()
    {
        GameMNG.UI.ClosePopupUI(this);
    }
}
