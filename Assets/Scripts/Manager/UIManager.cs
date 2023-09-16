using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager //������ UI Prefab���� ������ ������ �����ϴ� �޴���
{
    int _order = 10; //UI�� ������(�������� ������ ǥ��): 10���� �����ϴ� ������ 0�� �ƴϸ� ��� �������

    Stack<UI_Popup> _popupStack = new Stack<UI_Popup>(); //UI_Popup������Ʈ�� ��� ���� ����
    UI_Scene _sceneUI = null; //���� UI null�� �ʱ�ȭ

    public GameObject RootUI //�ֻ��� UI��ü�� ������Ƽ�� ������
    {
        get
        {
            GameObject rootUI = GameObject.Find("UI_Root");
            if(rootUI == null)
            {
                rootUI = new GameObject { name = "UI_Root" };
                rootUI.tag = "UI";
            }
            return rootUI;
        }
    }
    public void SetCanvas(GameObject canvas, bool sort = true) //canvas ������Ʈ�� canvas component ����
    {
        Canvas canvasComponent = Util.GetOrAddComponent<Canvas>(canvas);
        canvasComponent.renderMode = RenderMode.ScreenSpaceCamera; //canvas�� rendermode�� ī�޶� ����
        canvasComponent.worldCamera = Camera.main; //����ī�޶� ����
        canvasComponent.overrideSorting = true; //canvas�� ��ø�� ��� sort��

        if (sort)
        {
            canvasComponent.sortingOrder = _order; //�ڽ��� sortingOrder�� _order�� �����ϰ� ���� ���� canvas�� �� ����ٸ� �� ���� �ö�� �� �ֵ��� _order++
            _order++;
        }
        else
        {
            canvasComponent.sortingOrder = 1; //������ ǥ���� ����
        }
    }
    public T ShowPopupUI<T>(string name = null) where T : UI_Popup
    {
        if (string.IsNullOrEmpty(name))
        {
            name = typeof(T).Name;
        }

        GameObject PopupUI = GameMNG.Resource.MyInstantiate($"Scenes/UI/Popup/{name}");

        T popup = Util.GetOrAddComponent<T>(PopupUI);
        _popupStack.Push(popup);

        PopupUI.transform.SetParent(RootUI.transform);
        return popup;
    }
    public void ClosePopupUI()//PopUI�� �ݴ� �Լ�
    {
        if (_popupStack.Count == 0)
        {
            return;
        }
        UI_Popup popup = _popupStack.Pop();
        GameMNG.Resource.MyDestroy(popup.gameObject);
        popup = null;
        _order--;
    }
    public void ClosePopupUI(UI_Popup popup) //popupUI�� ���ÿ� ���� ���
    {
        if(_popupStack.Peek() != popup)
        {
            Debug.Log("Popup Close Fail");
            return;
        }
        ClosePopupUI();
    }
    public void CloseAllPopupUI()
    {
        while(_popupStack.Count > 0)
        {
            ClosePopupUI();
        }
    }
    public T ShowSceneUI<T>(string name = null) where T : UI_Scene //���� �⺻ UI�� ���ʷ� �������� T ������Ʈ�� �ٴ� �Լ�
    {
        if (string.IsNullOrEmpty(name))
        {
            name = typeof(T).Name;
        }

        GameObject sceneUIPrefab = GameMNG.Resource.MyInstantiate($"Scenes/UI/{name}"); //Prefabs/Scenes���� ã�ƿ� ����

        T sceneUI = Util.GetOrAddComponent<T>(sceneUIPrefab); //T ������Ʈ �߰�
        _sceneUI = sceneUI;

        sceneUIPrefab.transform.SetParent(RootUI.transform); //RootUI�� �θ�� ����
        return sceneUI;
    }
}
