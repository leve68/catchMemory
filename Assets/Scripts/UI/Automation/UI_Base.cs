using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;


public abstract class UI_Base : MonoBehaviour //��� UI�� ���� �߻�Ŭ������ ����(���� ��ü���� �������ٰ��� -> State interface�� �����)
{
    protected Dictionary<Type, UnityEngine.Object[]> objectDictionary = new Dictionary<Type, UnityEngine.Object[]>();
    public abstract void Init();

    protected void Bind<T>(Type type) where T : UnityEngine.Object //T�� UI������Ʈ�� �Է��ϰ�, UI������Ʈ�� ���ٸ� T�� GameObject�� ��
    {
        string[] names = Enum.GetNames(type); //typeof(enumName) �������� enum�� ��� ������ ������ �� �ִµ� GetNames�� �̸��� ������ -> string�迭�� names�� �̸����� ������
        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length]; //objects �� �迭�� ���̸� enum ����� ������ ��
        objectDictionary.Add(typeof(T), objects); //_objects�� ��ųʸ��� ������Ʈ�� Object�� Type�� Ű�� �ϰ� objects �迭�� value�� ����

        for(int i = 0; i< names.Length; i++)//T�� ���ϴ� ������Ʈ���� Dictionary�� value�� objects�� �߰���
        {
            if(typeof(T) == typeof(GameObject)) //T�� UI ������Ʈ�� �ʿ���� ���
            {
                objects[i] = Util.FindChild(gameObject, names[i], true);
            }
            else //T�� Button�̳� Text ó�� UI ������Ʈ�� �޷� �־�� �ϴ� ���
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
        //TryGetValue : objects �迭�� dictionary�� Value������ ��� �����ϰ� ���� �����Ѵٸ� true����
        if (objectDictionary.TryGetValue(typeof(T), out objects) == false) return null; //���� ���ٸ� null
        else return objects[idx] as T; //���� �����Ѵٸ� T Ÿ�� Key�� ���Ե� Value ������ objects�迭�� inx��° ���� T Ÿ������ ������
    }

    //Event�� ������ targetObject�� targetObject�� ������ assignedAction�� eventType�� �޾��� �� �۵��ϵ��� ���ε�
    public static void EventBind(GameObject targetObject, Action<PointerEventData> assignedAction, Define.UIEvent eventType = Define.UIEvent.ButtonUp)
    {
        UI_EventHandler eventComponent = Util.GetOrAddComponent<UI_EventHandler>(targetObject); //eventComponent�� tagetObject�� UI_eventHandler�� ����
        switch (eventType) //�ݹ����� �̺�Ʈ�� ������
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
