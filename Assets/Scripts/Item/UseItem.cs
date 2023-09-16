using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    // 아이템 사용 스크립트
    // useitem 버튼의 값이 item.allitems.아이템이름일 경우 해당 스크립트 갖고오기

    Item item;
    ActionController nowitem; // 받아온 아이템
    private GameObject UseitemBtn;

    private void Start()
    {
        UseitemBtn = GameObject.Find("quickSlot"); // useitem 오브젝트 넣음
    }

    private void FindItemName() // quickslot의 아이템값 찾는 함수 - quickSlot 눌렀을 때 함수 실행되게 / quickslot의 이미지가 아니라
    {

    }

    private void useItem() // 해당 아이템값 일 때, 해당 아이템 함수 실행
    {

    }

}
