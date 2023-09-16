using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Settings : UI_Popup
{
    public AudioMixer audioMixer;
    public static float BGMvol = 1f;
    public static float Effectvol = 1f;
    enum Buttons
    {
        stageSelect,
        credit,
        close,
        restart,
    }
    enum Sliders //gridPanel 사용할 것임
    {
        BGM,
        Effect,
    }
    private void Start()
    {
        Init();
    }
    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<Slider>(typeof(Sliders));

        audioMixer = GameMNG.Resource.Load<AudioMixer>("Sounds/AudioManager");

        Get<Slider>((int)Sliders.BGM).value = BGMvol;
        Get<Slider>((int)Sliders.Effect).value = Effectvol;
        audioMixer.SetFloat("BGMVolume", Mathf.Log10(Get<Slider>((int)Sliders.BGM).value) * 20);
        audioMixer.SetFloat("EffectVolume", Mathf.Log10(Get<Slider>((int)Sliders.Effect).value) * 20);

        Get<Button>((int)Buttons.close).gameObject.EventBind(ClosePopup);
        Get<Button>((int)Buttons.credit).gameObject.EventBind(ShowCredit);
        Get<Button>((int)Buttons.stageSelect).gameObject.EventBind(ShowStageSelectScene);
        Get<Slider>((int)Sliders.BGM).gameObject.EventBind(SetBGMVolume);
        Get<Slider>((int)Sliders.Effect).gameObject.EventBind(SetEffectVolume);

        Get<Button>((int)Buttons.restart).gameObject.EventBind(Restart);
    }
    public void ClosePopup(PointerEventData eventData)
    {
        GameMNG.Sound.Play("Effect/01_Option");
        GameMNG.UI.ClosePopupUI();
        Time.timeScale = 1;
    }
    public void ShowCredit(PointerEventData eventData)
    {
        GameMNG.Sound.Play("Effect/01_Option");
        GameMNG.UI.ShowPopupUI<Credit>();
    }
    public void ShowStageSelectScene(PointerEventData eventData)
    {
        GameMNG.Sound.Play("Effect/01_Option");
        GameMNG.UI.ShowPopupUI<ConfirmEndStage>("Confirm");
    }
    public void Restart(PointerEventData eventData)
    {
        GameMNG.Sound.Play("Effect/01_Option");
        GameMNG.UI.ShowPopupUI<ConfirmNewStart>("Confirm"); 
    }
    public void SetBGMVolume(PointerEventData eventData)
    {
        audioMixer.SetFloat("BGMVolume", Mathf.Log10(Get<Slider>((int)Sliders.BGM).value) * 20);
        BGMvol = Get<Slider>((int)Sliders.BGM).value;
    }
    public void SetEffectVolume(PointerEventData eventData)
    {
        audioMixer.SetFloat("EffectVolume", Mathf.Log10(Get<Slider>((int)Sliders.Effect).value) * 20);
        Effectvol = Get<Slider>((int)Sliders.Effect).value;
    }
}
