using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Credit : UI_Popup
{
    enum Buttons
    {
        close,
    }
    private void Start()
    {
        Init();
    }
    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));

        Get<Button>((int)Buttons.close).gameObject.EventBind(ClosePopup);
    }
    public void ClosePopup(PointerEventData eventData)
    {
        GameMNG.Sound.Play("Effect/01_Option");
        GameMNG.UI.ClosePopupUI();
    }
}
