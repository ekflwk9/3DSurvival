using System;
using System.Collections.Generic;
using UnityEngine;

public enum SoundCode
{
    Stop = 0,
    PlayerHit = 1,
}

public class SoundManager
{
    public float volume { get; private set; } = 0.5f;
    public event Void solidSound;

    private EffectSound effect;
    private MusicSound music;
    private Dictionary<SoundCode, AudioClip> sound = new Dictionary<SoundCode, AudioClip>();

    public void Load()
    {
        var sounds = Resources.LoadAll<AudioClip>("Sound");

        for (int i = 0; i < sounds.Length; i++)
        {
            if (Enum.TryParse<SoundCode>(sounds[i].name, out var soundType))
            {
                if (!sound.ContainsKey(soundType)) sound.Add(soundType, sounds[i]); 
            }

            else
            {
                Service.Log($"{sounds[i].name}라는 SoundCode값이 추가 되지 않음");
            }
        }
    }

    public void Clear()
    {
        solidSound = null;
    }

    public void Add(ISolidSound _solidSound)
    {
        solidSound += _solidSound.OnVolume;
    }

    public void Add(EffectSound _effectSource)
    {
        if (effect == null) effect = _effectSource;
        else Service.Log("\"EffectSound\"는 이미 SoundManager에 추가되어 있음");
    }

    public void Add(MusicSound _musicSource)
    {
        if (music == null) music = _musicSource;
        else Service.Log("\"MusicSound\"는 이미 SoundManager에 추가되어 있음");
    }

    public void SetVolume(float _volume)
    {
        volume = _volume;
        effect.SetVolume();
        music.SetVolume();
        solidSound?.Invoke();
    }

    /// <summary>
    /// Sound파일과 SoundManager/SoundCode에 추가된 경우에만 호출 가능함
    /// </summary>
    /// <param name="_sound"></param>
    public void OnEffect(SoundCode _sound)
    {
        if (_sound == SoundCode.Stop) Service.Log("\'Stop\"은 OnEffect에서 사용하는 값이 아님");
        else if (sound.ContainsKey(_sound)) effect.OnSound(sound[_sound]);
        else Service.Log($"{_sound.ToString()}은 사운드 파일에 없는 상태");
    }

    /// <summary>
    /// Sound파일과 SoundManager/SoundCode에 추가된 경우에만 호출 가능함
    /// </summary>
    /// <param name="_sound"></param>
    public void OnMusic(SoundCode _sound)
    {
        if (_sound == SoundCode.Stop) music.Stop();
        else if (sound.ContainsKey(_sound)) music.OnSound(sound[_sound]);
        else Service.Log($"{_sound.ToString()}은 사운드 파일에 없는 상태");
    }
}
