using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public static class Extension //확장메서드(예약클래스임) -> Extension안의 메서드들은 어디에서나 다른 클래스의 메서드처럼 사용가능
{
    public static T GetOrAddComponent<T>(this GameObject go) where T : UnityEngine.Component //getoraddcomponent를 어디에서나 쓰고 싶음
    {
        return Util.GetOrAddComponent<T>(go);
    }
    public static void EventBind(this GameObject go, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.ButtonUp) //eventbind를 어디서나 쓰고 싶음 // ButtonDown으로 수정
    {
        UI_Base.EventBind(go, action, type);
    }
}