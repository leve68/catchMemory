using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    // ������ ��� ��ũ��Ʈ
    // useitem ��ư�� ���� item.allitems.�������̸��� ��� �ش� ��ũ��Ʈ �������

    Item item;
    ActionController nowitem; // �޾ƿ� ������
    private GameObject UseitemBtn;

    private void Start()
    {
        UseitemBtn = GameObject.Find("quickSlot"); // useitem ������Ʈ ����
    }

    private void FindItemName() // quickslot�� �����۰� ã�� �Լ� - quickSlot ������ �� �Լ� ����ǰ� / quickslot�� �̹����� �ƴ϶�
    {

    }

    private void useItem() // �ش� �����۰� �� ��, �ش� ������ �Լ� ����
    {

    }

}
