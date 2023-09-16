using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// [CreateAssetMenu(fileName = "New Item",menuName ="New Item/item")]

public class Item : ScriptableObject // ������ �����̳� ���� / ��ũ��Ʈ�� �������� ���� ����
{
    public enum ItemSaveType // ������ ���� - ����/��û��
    {
        canSave,
        useNow,
    }

    public enum ItemType
    {
        yarn,
        cushion,
        needle,
        ball,
        mirror,
    }

    public ItemType itemType; // ��� ������ - � �����۰����� ����
    public string itemName; // ������ �̸�
    public ItemSaveType itemSaveType; // ������ ���� ����
    public Sprite itemImage; // �������� �̹���(�κ��丮 �ȿ� ���)
    public GameObject itemPrefab; // �������� ������(������ ���� �� ���������� ��)

    public bool IsAcquired
    {
        get
        {
            return PlayerPrefs.GetInt($"{itemType}IsAcquired") > 0;
        }
        set
        {
			PlayerPrefs.SetInt($"{itemType}IsAcquired", value ? 1 : 0);
		}
    }
}
