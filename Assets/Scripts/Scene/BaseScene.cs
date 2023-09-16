using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseScene : MonoBehaviour
{
    public Define.Scenes SceneType { get; protected set; } = Define.Scenes.Lobby; // ����Ʈ�� �κ�ȭ������ ���� //�������� ������ �� �� ������ set�� �ڽĵ鸸 ����

    void Awake()
    {
        Init();
    }

    protected virtual void Init()//���� EventSystem�� ���� ��� ����
    {
        Object obj = GameObject.FindObjectOfType(typeof(EventSystem));
        if (obj == null)
            GameMNG.Resource.MyInstantiate("Scenes/UI/EventSystem").name = "EventSystem";
    }

    public abstract void Clear();
}
