using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager
{
    AudioSource[] _audioSources = new AudioSource[(int)Define.Sound.MaxCount];  //일종의 mp3플레이어
    Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>(); //플레이할 음원
    public AudioMixer audioMixer;

    public void Init()
    {
        GameObject root = GameObject.Find("SoundMNG");
        audioMixer = GameMNG.Resource.Load<AudioMixer>("Sounds/AudioManager");
        if (root == null)
        {
            root = new GameObject { name = "SoundMNG" };
            Object.DontDestroyOnLoad(root);

            string[] soundNames = System.Enum.GetNames(typeof(Define.Sound));
            for (int i = 0; i < soundNames.Length - 1; i++)
            {
                GameObject go = new GameObject { name = soundNames[i] };
                _audioSources[i] = go.AddComponent<AudioSource>();
                go.transform.parent = root.transform;
            }
            _audioSources[(int)Define.Sound.Bgm].loop = true; // bgm 재생기는 무한 반복
        }
    }

    public void Clear() //사운드 모두 끄고 제거
    {
        foreach (AudioSource audioSource in _audioSources)
        {
            audioSource.clip = null;
            audioSource.Stop();
        }
        _audioClips.Clear();
    }
    public void Play(string path, Define.Sound type = Define.Sound.Effect, float pitch = 1.0f) //이 함수를 사용하여 사운드 재생 (원하는 파일을 동적으로 가져와 재생함)
    {
        AudioClip audioClip = GetOrAddAudioClip(path, type);
        Play(audioClip, type, pitch);
    }

    public void Play(AudioClip audioClip, Define.Sound type = Define.Sound.Effect, float pitch = 1.0f)
    {
        if (audioClip == null)
            return;

        if (type == Define.Sound.Bgm) // BGM 배경음악 재생
        {
            AudioSource audioSource = _audioSources[(int)Define.Sound.Bgm];
            if (audioSource.isPlaying)
                audioSource.Stop();

            audioSource.pitch = pitch;
            audioSource.clip = audioClip;
            audioSource.outputAudioMixerGroup = audioMixer.FindMatchingGroups("BGM")[0];
            audioSource.Play();
        }
        else // Effect 효과음 재생
        {
            AudioSource audioSource = _audioSources[(int)Define.Sound.Effect];
            audioSource.pitch = pitch;
            audioSource.outputAudioMixerGroup = audioMixer.FindMatchingGroups("Effect")[0];
            audioSource.PlayOneShot(audioClip);
        }
    }

    AudioClip GetOrAddAudioClip(string path, Define.Sound type = Define.Sound.Effect)
    {
        if (path.Contains("Sounds/") == false)
            path = $"Sounds/{path}"; // Sound 폴더 안에 저장될 수 있도록

        AudioClip audioClip = null;

        if (type == Define.Sound.Bgm) // BGM 배경음악 클립 붙이기
        {
            audioClip = GameMNG.Resource.Load<AudioClip>(path);
        }
        else // Effect 효과음 클립 붙이기
        {
            if (_audioClips.TryGetValue(path, out audioClip) == false)
            {
                audioClip = GameMNG.Resource.Load<AudioClip>(path);
                _audioClips.Add(path, audioClip);
            }
        }

        if (audioClip == null)
            Debug.Log($"AudioClip Missing ! {path}");

        return audioClip;
    }
}
