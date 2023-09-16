using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class UI_EventHandler : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    //Action을 이용한 콜백 이벤트 정의
    public Action<PointerEventData> OnClickHandler = null;
    public Action<PointerEventData> OnDragHandler = null;
    public Action<PointerEventData> OnClickUpHandler = null;
    
    public void OnPointerDown(PointerEventData eventData) //클릭 이벤트 발생 시 Invoke
    {
        if(OnClickHandler != null)
        {
            OnClickHandler.Invoke(eventData);
        }
    }
    public void OnDrag(PointerEventData eventData) //드래그 이벤트 발생 시 Invoke
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
