using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;


public abstract class UI_Base : MonoBehaviour //모든 UI의 조상 추상클래스로 선언(하위 객체들이 구현해줄것임 -> State interface와 비슷함)
{
    protected Dictionary<Type, UnityEngine.Object[]> objectDictionary = new Dictionary<Type, UnityEngine.Object[]>();
    public abstract void Init();

    protected void Bind<T>(Type type) where T : UnityEngine.Object //T는 UI컴포넌트를 입력하고, UI컴포넌트가 없다면 T는 GameObject가 됨
    {
        string[] names = Enum.GetNames(type); //typeof(enumName) 형식으로 enum의 모든 값들을 가져올 수 있는데 GetNames로 이름을 추출함 -> string배열에 names란 이름으로 저장함
        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length]; //objects 란 배열의 길이를 enum 목록의 개수로 함
        objectDictionary.Add(typeof(T), objects); //_objects란 딕셔너리는 컴포넌트나 Object의 Type을 키로 하고 objects 배열을 value로 가짐

        for(int i = 0; i< names.Length; i++)//T에 속하는 오브젝트들을 Dictionary의 value인 objects에 추가함
        {
            if(typeof(T) == typeof(GameObject)) //T가 UI 컴포넌트가 필요없는 경우
            {
                objects[i] = Util.FindChild(gameObject, names[i], true);
            }
            else //T가 Button이나 Text 처럼 UI 컴포넌트가 달려 있어야 하는 경우
            {
                objects[i] = Util.FindChild<T>(gameObject, names[i], true);
            }
            if(objects[i] == null)
            {
                Debug.Log($"Binding Failed {names[i]}");
            }
        }
    }
    protected T Get<T>(int idx) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objects = null;
        //TryGetValue : objects 배열에 dictionary의 Value값들을 모두 저장하고 값이 존재한다면 true리턴
        if (objectDictionary.TryGetValue(typeof(T), out objects) == false) return null; //값이 없다면 null
        else return objects[idx] as T; //값이 존재한다면 T 타입 Key에 포함된 Value 값들인 objects배열중 inx번째 값을 T 타입으로 리턴함
    }

    //Event를 적용할 targetObject와 targetObject를 움직일 assignedAction을 eventType을 받았을 때 작동하도록 바인딩
    public static void EventBind(GameObject targetObject, Action<PointerEventData> assignedAction, Define.UIEvent eventType = Define.UIEvent.ButtonUp)
    {
        UI_EventHandler eventComponent = Util.GetOrAddComponent<UI_EventHandler>(targetObject); //eventComponent에 tagetObject의 UI_eventHandler를 넣음
        switch (eventType) //콜백으로 이벤트를 구독함
        {
            case Define.UIEvent.ButtonDown:
                eventComponent.OnClickHandler -= assignedAction;
                eventComponent.OnClickHandler += assignedAction;
                break;
            case Define.UIEvent.Drag:
                eventComponent.OnDragHandler -= assignedAction;
                eventComponent.OnDragHandler += assignedAction;
                break;
            case Define.UIEvent.ButtonUp:
                eventComponent.OnClickUpHandler -= assignedAction;
                eventComponent.OnClickUpHandler += assignedAction;
                break;
        }
    }
}
