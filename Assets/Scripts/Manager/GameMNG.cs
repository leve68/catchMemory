using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMNG : MonoBehaviour
{
    public static GameMNG sharedInstance = null; // �̱���
    ResourceManager _resource = new ResourceManager();
    UIManager _ui = new UIManager();
    SceneMNG _scene = new SceneMNG();
    DataManager _data = new DataManager();
    SoundManager _sound = new SoundManager();

    static GameMNG Instance { get { Init();  return sharedInstance; } }
    public static ResourceManager Resource { get { return Instance._resource; } }
    public static UIManager UI { get { return Instance._ui; } }
    public static SceneMNG Scene { get { return Instance._scene; } }
    public static DataManager Data { get { return Instance._data; } }
    public static SoundManager Sound { get { return Instance._sound; } }

    static void Init()
    {
        if(sharedInstance == null)
        {
            GameObject go = GameObject.Find("GameMNG");
            if(go == null)
            {
                go = new GameObject { name = "GameMNG" };
                go.AddComponent<GameMNG>();
            }
            go.tag = "Manager";
            sharedInstance = go.GetComponent<GameMNG>();
            GameObject.DontDestroyOnLoad(go);
            sharedInstance._data.Init(); //data manager�ʱ�ȭ
            sharedInstance._sound.Init(); //sound manager�ʱ�ȭ
        }
    }

    private void Start()
    {
        Init();
    }

    ItemList theitemlist;
    Character character;

    public void SaveData()
    {
        //UI�� �����ؾ� �ϴ� �����͵� ����
        // 들어간 아이템 저장
        // itemslot[]에서 isAcquired가 켜진 아이템
        /*for(int i=0; i<5; i++)
        {
            if(theitemlist.itemslots[i].isAcquired == true)
            {
                //GameObject.FindWithTag("UI").GetComponentInChildren<ItemSlot>();
                // 여기 itemslot[i].item 불러오면됨
            }

        }
        */
    }
    public void LoadData()
    {
        //����� �����͵� ȣ��
        //GameObject.FindWithTag("UI").GetComponentInChildren<ItemSlot>();

    }
}
