using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public static class Extension //Ȯ��޼���(����Ŭ������) -> Extension���� �޼������ ��𿡼��� �ٸ� Ŭ������ �޼���ó�� ��밡��
{
    public static T GetOrAddComponent<T>(this GameObject go) where T : UnityEngine.Component //getoraddcomponent�� ��𿡼��� ���� ����
    {
        return Util.GetOrAddComponent<T>(go);
    }
    public static void EventBind(this GameObject go, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.ButtonUp) //eventbind�� ��𼭳� ���� ���� // ButtonDown���� ����
    {
        UI_Base.EventBind(go, action, type);
    }
}