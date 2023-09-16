using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class Util
{
    public static T FindChild<T>(GameObject canvas, string name = null , bool recursive = true) where T : UnityEngine.Object // canvas 산하에서 name이 같은 T 컴포넌트 찾기
    {
        if (canvas == null) return null; // canvas 없으면 null

        if (!recursive)
        {
            for(int i = 0;i<canvas.transform.childCount; i++) // canvas산하의 Object개수만큼 순회 -> 상속관계는 Transform 컴포넌트가 들고 있기 때문에 transform사용
            {
                Transform canvasChild = canvas.transform.GetChild(i); //Transform 타입의 canvasChild에 i번째 canvas 자식을 넣음
                if(string.IsNullOrEmpty(name) || canvasChild.name == name) //name이 필요없어서 null이거나 canvas에서 탐색한 name이 우리가 찾는 name과 같으면
                {
                    T component = canvasChild.GetComponent<T>(); //T 타입 component변수에 canvas에서 탐색한 child의 Tcomponent를 넣음
                    if (component != null) return component; //만약 component가 null이 아니면 우리가 찾는 이름을 가진 Object의 T 타입 컴포넌트를 리턴함
                }
            }
        }
        else
        {
            foreach(T component in canvas.GetComponentsInChildren<T>()) //canvas하위 T타입 자식들을 모두 순회하며 T타입 변수 component에 넣음
            {
                if(string.IsNullOrEmpty(name) || component.name == name) //name이 필요없거나 canvas에서 탐색한 name이 우리가 찾는 name과 같으면
                {
                    return component; //T 타입 컴포넌트 리턴함
                }
            }
        }
        return null; //모든 값 반환을 위한 null
    }
    public static GameObject FindChild(GameObject canvas, string name = null, bool recursive = true) //canvas 산하에서 name이 같은 GameObject 찾기
    {
        //Trnasfrom 타입의 변수 canvasChild에 Transfrom컴포넌트를 가진 canvas산하의 모든 객체를 조사하고 name이 같은게 있으면 그 객체의 Transfrom컴포넌트 반환
        Transform canvasChild = FindChild<Transform>(canvas, name, recursive); 
        if (canvasChild == null) return null; //null 이면 null
        else return canvasChild.gameObject; //canvasChild가 포함된 Object리턴
    }
    public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component //Add + GetComponent를 생각하지 않고 쓰기 위함
    {
        T component = go.GetComponent<T>();
        if(component == null)
        {
            component = go.AddComponent<T>();
        }
        return component;
    }
    /* 해상도 설정하는 함수 */
    public static void SetResolution()
    {
        int setWidth = 3200; // 사용자 설정 너비
        int setHeight = 1440; // 사용자 설정 높이

        int deviceWidth = Screen.width; // 기기 너비 저장
        int deviceHeight = Screen.height; // 기기 높이 저장

        Screen.SetResolution(setWidth, (int)(((float)deviceHeight / deviceWidth) * setWidth), true); // SetResolution 함수 제대로 사용하기

        if ((float)setWidth / setHeight < (float)deviceWidth / deviceHeight) // 기기의 해상도 비가 더 큰 경우
        {
            float newWidth = ((float)setWidth / setHeight) / ((float)deviceWidth / deviceHeight); // 새로운 너비
            Camera.main.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f); // 새로운 Rect 적용
        }
        else // 게임의 해상도 비가 더 큰 경우
        {
            float newHeight = ((float)deviceWidth / deviceHeight) / ((float)setWidth / setHeight); // 새로운 높이
            Camera.main.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight); // 새로운 Rect 적용
        }
    }
}
