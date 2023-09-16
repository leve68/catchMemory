using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerControl : UI_Scene //canvas�� ���� UI ������Ʈ��
{
    LIfe _life;
    Character _characterControl;
    public bool isMovingLeft = false;
    public bool isMovingRight = false;
    public bool isJumpTriggerd = false;
    public bool isItemUseTriggerd = false;
    public string ItemName;
    enum Buttons
    {
        moveLeft,
        moveRight,
        jump,
        Slot,
        Slot1,
        Slot2,
        settings,
    }
    enum Images
    {
        heart1,
        heart2,
        heart3,
    }
    enum Texts
    {
        currentStage,
    }
    enum GameObjects //gridPanel ����� ����
    {
        ItemList,
        Inventory,
    }
    private void Start()
    {
        Init();
    }
    private void Update()
    {

    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<Image>(typeof(Images));
        Bind<GameObject>(typeof(GameObjects));
        Bind<Text>(typeof(Texts));

        //OnDamaged�� ����� _life����
        _life = GameObject.FindWithTag("Player").GetComponent<LIfe>();
        _characterControl = GameObject.FindWithTag("Player").GetComponent<Character>();
        GetCurrentStage();

        //��ư�� ���� �ο�
        _characterControl = GameObject.FindWithTag("Player").GetComponent<Character>();
        Get<Button>((int)Buttons.moveLeft).gameObject.EventBind(MovingLefttrue, Define.UIEvent.ButtonDown);
        Get<Button>((int)Buttons.moveLeft).gameObject.EventBind(MovingLeftfalse);
        Get<Button>((int)Buttons.moveRight).gameObject.EventBind(MovingRighttrue, Define.UIEvent.ButtonDown);
        Get<Button>((int)Buttons.moveRight).gameObject.EventBind(MovingRightfalse);
        Get<Button>((int)Buttons.jump).gameObject.EventBind(OnJumped, Define.UIEvent.ButtonDown);

        Get<Button>((int)Buttons.settings).gameObject.EventBind(ShowSettings);

        //Image�� ���� �ο�
       // Get<Image>((int)Images.Image1).gameObject.EventBind(ChangeQuickSlotImage);
        //Get<Image>((int)Images.Image2).gameObject.EventBind(ChangeQuickSlotImage);
        //Get<Image>((int)Images.Image3).gameObject.EventBind(ChangeQuickSlotImage);
    }
    public void LifeChange()
    {
        if (_life.GetLife() == 3) {
            Get<Image>((int)Images.heart3).gameObject.SetActive(true);
        }
        if (_life.GetLife() == 2)
        {
            Get<Image>((int)Images.heart3).gameObject.SetActive(false);
            Get<Image>((int)Images.heart2).gameObject.SetActive(true);
        }
        if (_life.GetLife() == 1)
        {
            Get<Image>((int)Images.heart2).gameObject.SetActive(false);
            Get<Image>((int)Images.heart1).gameObject.SetActive(true);
        }
        if (_life.GetLife() == 0)
        {
            Get<Image>((int)Images.heart1).gameObject.SetActive(false);
        }
    }
    public void MovingLefttrue(PointerEventData eventData)
    {
        isMovingLeft = true;
    }
    public void MovingLeftfalse(PointerEventData eventData)
    {
        isMovingLeft = false;
    }
    public void MovingRighttrue(PointerEventData eventData)
    {
        isMovingRight = true;
    }
    public void MovingRightfalse(PointerEventData eventData)
    {
        isMovingRight = false;
    }
    public void OnJumped(PointerEventData eventData)
    {
        isJumpTriggerd = true;
    }
    public void OnUseYarn(PointerEventData eventData)
    {
        GameMNG.Sound.Play("Effect/04_Item_Ball");

        isItemUseTriggerd = true;
        Get<Button>((int)Buttons.Slot).GetComponent<Slot>().itemCount--;
        ItemName = "Yarn";
    }
    public void OnUseMirror(PointerEventData eventData)
    {
        GameMNG.Sound.Play("Effect/04_Item_Ball");

        isItemUseTriggerd = true;
        Get<Button>((int)Buttons.Slot2).GetComponent<Slot>().itemCount--;
        ItemName = "Mirror";
    }
    public void OnUseBall(PointerEventData eventData)
    {
        GameMNG.Sound.Play("Effect/04_Item_Ball");

        isItemUseTriggerd = true;
        Get<Button>((int)Buttons.Slot1).GetComponent<Slot>().itemCount--;
        ItemName = "Ball";
    }
    public void ShowItem()
    {
        if (Get<Button>((int)Buttons.Slot).GetComponent<Image>().color.a != 0)
        {
            if (Get<Button>((int)Buttons.Slot).GetComponent<Slot>().itemCount > 0)
            {
                Get<Button>((int)Buttons.Slot).gameObject.EventBind(OnUseYarn);
            }
            else Destroy(Get<Button>((int)Buttons.Slot).gameObject.GetComponent<UI_EventHandler>());
            Get<Button>((int)Buttons.Slot).GetComponent<Slot>().UpdateText();
        }
        if (Get<Button>((int)Buttons.Slot1).GetComponent<Image>().color.a != 0)
        {
            if (Get<Button>((int)Buttons.Slot1).GetComponent<Slot>().itemCount > 0)
            {
                Get<Button>((int)Buttons.Slot1).gameObject.EventBind(OnUseBall);
            }
            else Destroy(Get<Button>((int)Buttons.Slot1).gameObject.GetComponent<UI_EventHandler>());
            Get<Button>((int)Buttons.Slot1).GetComponent<Slot>().UpdateText();
        }
        if (Get<Button>((int)Buttons.Slot2).GetComponent<Image>().color.a != 0)
        {
            if (Get<Button>((int)Buttons.Slot2).GetComponent<Slot>().itemCount > 0)
            {
                Get<Button>((int)Buttons.Slot2).gameObject.EventBind(OnUseMirror);
            }
            else Destroy(Get<Button>((int)Buttons.Slot2).gameObject.GetComponent<UI_EventHandler>());
            Get<Button>((int)Buttons.Slot2).GetComponent<Slot>().UpdateText();
        }
    }
    public void DoNothing(PointerEventData eventData)
    {
        return;
    }
    public void ShowSettings(PointerEventData eventData)
    {
        GameMNG.Sound.Play("Effect/01_Option");
        GameMNG.UI.ShowPopupUI<Settings>("Settings");
        Time.timeScale = 0;
    }
    /*public void ChangeQuickSlotImage(PointerEventData eventData)
    {
        if (eventData.pointerPress.gameObject == Get<Image>((int)Images.Image1).gameObject)
        // image ������Ʈ�� �̹����� ������ -> slot ������Ʈ�� ������ �ִ� image ������Ʈ�� �̹����� ������
        // �޾ƿ� item���� ���� ��ũ��Ʈ ����
        {
            Get<Button>((int)Buttons.quickSlot).image.sprite = Get<Image>((int)Images.Image1).sprite;
        }
        if (eventData.pointerPress.gameObject == Get<Image>((int)Images.Image2).gameObject)
        {
            Get<Button>((int)Buttons.quickSlot).image.sprite = Get<Image>((int)Images.Image2).sprite;
        }
        if (eventData.pointerPress.gameObject == Get<Image>((int)Images.Image3).gameObject)
        {
            Get<Button>((int)Buttons.quickSlot).image.sprite = Get<Image>((int)Images.Image3).sprite;
        }
    }*/
    public Item GetItemName()
    {
        return ItemList.currentItem;
    }
    public void GetCurrentStage()
    {
        GameObject SceneMNG = GameObject.FindWithTag("Scene");
        if (SceneMNG.GetComponent<StageScene1>() != null)
        {
            Get<Text>((int)Texts.currentStage).text = "스테이지 1";
            _characterControl.currentStage = 1;
        }
        if (SceneMNG.GetComponent<StageScene2>() != null)
        {
            Get<Text>((int)Texts.currentStage).text = "스테이지 2";
            _characterControl.currentStage = 2;
        }
        if (SceneMNG.GetComponent<StageScene3>() != null)
        {
            Get<Text>((int)Texts.currentStage).text = "스테이지 3";
            _characterControl.currentStage = 3;
        }
        if (SceneMNG.GetComponent<StageScene4>() != null)
        {
            Get<Text>((int)Texts.currentStage).text = "스테이지 4";
            _characterControl.currentStage = 4;
        }
        if (SceneMNG.GetComponent<StageScene5>() != null)
        {
            Get<Text>((int)Texts.currentStage).text = "스테이지 5";
            _characterControl.currentStage = 5;
        }
    }
}
