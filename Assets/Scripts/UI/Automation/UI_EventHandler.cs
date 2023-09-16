using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class UI_EventHandler : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    //Action�� �̿��� �ݹ� �̺�Ʈ ����
    public Action<PointerEventData> OnClickHandler = null;
    public Action<PointerEventData> OnDragHandler = null;
    public Action<PointerEventData> OnClickUpHandler = null;
    
    public void OnPointerDown(PointerEventData eventData) //Ŭ�� �̺�Ʈ �߻� �� Invoke
    {
        if(OnClickHandler != null)
        {
            OnClickHandler.Invoke(eventData);
        }
    }
    public void OnDrag(PointerEventData eventData) //�巡�� �̺�Ʈ �߻� �� Invoke
    {
        if(OnDragHandler != null)
        {
            OnDragHandler.Invoke(eventData);
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (OnClickUpHandler != null)
        {
            OnClickUpHandler.Invoke(eventData);
        }
    }
}
