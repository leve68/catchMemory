using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseScene : MonoBehaviour
{
    public Define.Scenes SceneType { get; protected set; } = Define.Scenes.Lobby; // 디폴트를 로비화면으로 설정 //씬정보는 누구나 볼 수 있지만 set은 자식들만 가능

    void Awake()
    {
        Init();
    }

    protected virtual void Init()//씬에 EventSystem이 없을 경우 방지
    {
        Object obj = GameObject.FindObjectOfType(typeof(EventSystem));
        if (obj == null)
            GameMNG.Resource.MyInstantiate("Scenes/UI/EventSystem").name = "EventSystem";
    }

    public abstract void Clear();
}
