using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    public T Load<T>(string path) where T : Object //Asset���Ͽ��� �ʿ��Ѱ� ������
    {
        T go =  Resources.Load<T>(path);
        return go;
    }
    public GameObject MyInstantiate(string path, Transform parant = null) //Prefabs ���Ͽ��� path�� �Էµ� ��θ� ���� ��ü�� ã�ƿ�
    {
        GameObject prefab = Load<GameObject>($"Prefabs/{path}");
        if(prefab == null)
        {
            Debug.Log($"Faild to load Prefab : {path}");
            return null;
        }

        GameObject objectLoaded = Object.Instantiate(prefab, parant);
        int index = objectLoaded.name.IndexOf("(Clone)");
        if(index > 0)
        {
            objectLoaded.name = objectLoaded.name.Substring(0, index);
        }
        return objectLoaded;
    }
    public void MyDestroy(GameObject objectDestroyed) //������ �� ����
    {
        Object.Destroy(objectDestroyed);
    }
}
