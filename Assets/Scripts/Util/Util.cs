using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class Util
{
    public static T FindChild<T>(GameObject canvas, string name = null , bool recursive = true) where T : UnityEngine.Object // canvas ���Ͽ��� name�� ���� T ������Ʈ ã��
    {
        if (canvas == null) return null; // canvas ������ null

        if (!recursive)
        {
            for(int i = 0;i<canvas.transform.childCount; i++) // canvas������ Object������ŭ ��ȸ -> ��Ӱ���� Transform ������Ʈ�� ��� �ֱ� ������ transform���
            {
                Transform canvasChild = canvas.transform.GetChild(i); //Transform Ÿ���� canvasChild�� i��° canvas �ڽ��� ����
                if(string.IsNullOrEmpty(name) || canvasChild.name == name) //name�� �ʿ��� null�̰ų� canvas���� Ž���� name�� �츮�� ã�� name�� ������
                {
                    T component = canvasChild.GetComponent<T>(); //T Ÿ�� component������ canvas���� Ž���� child�� Tcomponent�� ����
                    if (component != null) return component; //���� component�� null�� �ƴϸ� �츮�� ã�� �̸��� ���� Object�� T Ÿ�� ������Ʈ�� ������
                }
            }
        }
        else
        {
            foreach(T component in canvas.GetComponentsInChildren<T>()) //canvas���� TŸ�� �ڽĵ��� ��� ��ȸ�ϸ� TŸ�� ���� component�� ����
            {
                if(string.IsNullOrEmpty(name) || component.name == name) //name�� �ʿ���ų� canvas���� Ž���� name�� �츮�� ã�� name�� ������
                {
                    return component; //T Ÿ�� ������Ʈ ������
                }
            }
        }
        return null; //��� �� ��ȯ�� ���� null
    }
    public static GameObject FindChild(GameObject canvas, string name = null, bool recursive = true) //canvas ���Ͽ��� name�� ���� GameObject ã��
    {
        //Trnasfrom Ÿ���� ���� canvasChild�� Transfrom������Ʈ�� ���� canvas������ ��� ��ü�� �����ϰ� name�� ������ ������ �� ��ü�� Transfrom������Ʈ ��ȯ
        Transform canvasChild = FindChild<Transform>(canvas, name, recursive); 
        if (canvasChild == null) return null; //null �̸� null
        else return canvasChild.gameObject; //canvasChild�� ���Ե� Object����
    }
    public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component //Add + GetComponent�� �������� �ʰ� ���� ����
    {
        T component = go.GetComponent<T>();
        if(component == null)
        {
            component = go.AddComponent<T>();
        }
        return component;
    }
    /* �ػ� �����ϴ� �Լ� */
    public static void SetResolution()
    {
        int setWidth = 3200; // ����� ���� �ʺ�
        int setHeight = 1440; // ����� ���� ����

        int deviceWidth = Screen.width; // ��� �ʺ� ����
        int deviceHeight = Screen.height; // ��� ���� ����

        Screen.SetResolution(setWidth, (int)(((float)deviceHeight / deviceWidth) * setWidth), true); // SetResolution �Լ� ����� ����ϱ�

        if ((float)setWidth / setHeight < (float)deviceWidth / deviceHeight) // ����� �ػ� �� �� ū ���
        {
            float newWidth = ((float)setWidth / setHeight) / ((float)deviceWidth / deviceHeight); // ���ο� �ʺ�
            Camera.main.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f); // ���ο� Rect ����
        }
        else // ������ �ػ� �� �� ū ���
        {
            float newHeight = ((float)deviceWidth / deviceHeight) / ((float)setWidth / setHeight); // ���ο� ����
            Camera.main.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight); // ���ο� Rect ����
        }
    }
}
