using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene_Anim : BaseScene
{

    // ������ �ִϸ����� ����, �ʰ� �̹��� �߰� ������ ����
    // ������Ʈ ��� �� ������Ʈ ��°�� ���̵�ƿ� / ���̵�ƿ��� �ִϸ��̼� �̺�ƮŰ �����ؼ� / �ִϸ��̼� ������ �� ��ȣ �����ؼ� / �ش� ��ȣ ���ֱ�
    // �������� �ִϸ��̼� �̺�ƮŰ ���� �����ؼ� �� ��ȯ


    [SerializeField] public List<GameObject> Scenes = new List<GameObject>();

    //public int PageNum = 0;
    private Animator animator;
    public static int SceneNum = 6;
    public GameObject TestScene;

    protected override void Init() // ��� ���� Awake() �ȿ��� �����
    {
        base.Init();

        SceneType = Define.Scenes.CutScene;

        GameMNG.UI.ShowSceneUI<CutScene>();
    }

    public override void Clear()
    {

    }

    void Start()
    {
        AnimatorPlay();
    }

    void AnimatorPlay()
    {
        if(SceneNum == 0)
        {
            GameMNG.Sound.Play("BGM/ĳġ�޸�_�ƾ�", Define.Sound.Bgm);
            Scenes[SceneNum].transform.GetChild(0).gameObject.SetActive(true);
        }
        if (SceneNum == 1)
        {
            GameMNG.Sound.Play("BGM/ĳġ�޸�_�ƾ�", Define.Sound.Bgm);
            Scenes[SceneNum].transform.GetChild(0).gameObject.SetActive(true);
        }
        if (SceneNum == 2)
        {
            GameMNG.Sound.Play("BGM/ĳġ�޸�_�ƾ�", Define.Sound.Bgm);
            Scenes[SceneNum].transform.GetChild(0).gameObject.SetActive(true);
        }
        if (SceneNum == 3)
        {
            GameMNG.Sound.Play("BGM/ĳġ�޸�_�ƾ�", Define.Sound.Bgm);
            Scenes[SceneNum].transform.GetChild(0).gameObject.SetActive(true);
        }
        if (SceneNum == 4)
        {
            GameMNG.Sound.Play("BGM/ĳġ�޸�_�ƾ�", Define.Sound.Bgm);
            Scenes[SceneNum].transform.GetChild(0).gameObject.SetActive(true);
        }
        if (SceneNum == 5)
        {
            GameMNG.Sound.Play("BGM/ĳġ�޸�_st3_03", Define.Sound.Bgm);
            Scenes[SceneNum].transform.GetChild(0).gameObject.SetActive(true);
        }
        if (SceneNum == 6)
        {
            GameMNG.Sound.Play("BGM/ĳġ�޸�_st3_03", Define.Sound.Bgm);
            Scenes[SceneNum].transform.GetChild(0).gameObject.SetActive(true);
        }

    }


}
