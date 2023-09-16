using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager //씬에서 UI Prefab들의 생성과 삭제를 관리하는 메니저
{
    int _order = 10; //UI의 순서임(높을수록 상위에 표시): 10부터 시작하는 이유는 0만 아니면 사실 상관없음

    Stack<UI_Popup> _popupStack = new Stack<UI_Popup>(); //UI_Popup컴포넌트를 담는 스택 생성
    UI_Scene _sceneUI = null; //고정 UI null로 초기화

    public GameObject RootUI //최상위 UI객체를 프로퍼티로 가져옴
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
    public void SetCanvas(GameObject canvas, bool sort = true) //canvas 오브젝트의 canvas component 셋팅
    {
        Canvas canvasComponent = Util.GetOrAddComponent<Canvas>(canvas);
        canvasComponent.renderMode = RenderMode.ScreenSpaceCamera; //canvas의 rendermode를 카메라에 맞춤
        canvasComponent.worldCamera = Camera.main; //메인카메라 기준
        canvasComponent.overrideSorting = true; //canvas가 중첩될 경우 sort함

        if (sort)
        {
            canvasComponent.sortingOrder = _order; //자신의 sortingOrder를 _order로 설정하고 만약 다음 canvas가 또 생긴다면 내 위에 올라올 수 있도록 _order++
            _order++;
        }
        else
        {
            canvasComponent.sortingOrder = 1; //무조건 표시할 것임
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
    public void ClosePopupUI()//PopUI를 닫는 함수
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
    public void ClosePopupUI(UI_Popup popup) //popupUI가 스택에 없는 경우
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
    public T ShowSceneUI<T>(string name = null) where T : UI_Scene //씬의 기본 UI를 최초로 가져오고 T 컴포넌트를 다는 함수
    {
        if (string.IsNullOrEmpty(name))
        {
            name = typeof(T).Name;
        }

        GameObject sceneUIPrefab = GameMNG.Resource.MyInstantiate($"Scenes/UI/{name}"); //Prefabs/Scenes에서 찾아올 것임

        T sceneUI = Util.GetOrAddComponent<T>(sceneUIPrefab); //T 컴포넌트 추가
        _sceneUI = sceneUI;

        sceneUIPrefab.transform.SetParent(RootUI.transform); //RootUI를 부모로 가짐
        return sceneUI;
    }
}
