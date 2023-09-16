using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene_Anim : BaseScene
{

    // 각각의 애니메이터 만들어서, 늦게 이미지 뜨게 일일이 조정
    // 오브젝트 묶어서 각 오브젝트 통째로 페이드아웃 / 페이드아웃은 애니메이션 이벤트키 설정해서 / 애니메이션 시작할 때 번호 지정해서 / 해당 번호 꺼주기
    // 끝났을때 애니메이션 이벤트키 따로 설정해서 씬 전환


    [SerializeField] public List<GameObject> Scenes = new List<GameObject>();

    //public int PageNum = 0;
    private Animator animator;
    public static int SceneNum = 6;
    public GameObject TestScene;

    protected override void Init() // 상속 받은 Awake() 안에서 실행됨
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
            GameMNG.Sound.Play("BGM/캐치메모리_컷씬", Define.Sound.Bgm);
            Scenes[SceneNum].transform.GetChild(0).gameObject.SetActive(true);
        }
        if (SceneNum == 1)
        {
            GameMNG.Sound.Play("BGM/캐치메모리_컷씬", Define.Sound.Bgm);
            Scenes[SceneNum].transform.GetChild(0).gameObject.SetActive(true);
        }
        if (SceneNum == 2)
        {
            GameMNG.Sound.Play("BGM/캐치메모리_컷씬", Define.Sound.Bgm);
            Scenes[SceneNum].transform.GetChild(0).gameObject.SetActive(true);
        }
        if (SceneNum == 3)
        {
            GameMNG.Sound.Play("BGM/캐치메모리_컷씬", Define.Sound.Bgm);
            Scenes[SceneNum].transform.GetChild(0).gameObject.SetActive(true);
        }
        if (SceneNum == 4)
        {
            GameMNG.Sound.Play("BGM/캐치메모리_컷씬", Define.Sound.Bgm);
            Scenes[SceneNum].transform.GetChild(0).gameObject.SetActive(true);
        }
        if (SceneNum == 5)
        {
            GameMNG.Sound.Play("BGM/캐치메모리_st3_03", Define.Sound.Bgm);
            Scenes[SceneNum].transform.GetChild(0).gameObject.SetActive(true);
        }
        if (SceneNum == 6)
        {
            GameMNG.Sound.Play("BGM/캐치메모리_st3_03", Define.Sound.Bgm);
            Scenes[SceneNum].transform.GetChild(0).gameObject.SetActive(true);
        }

    }


}
