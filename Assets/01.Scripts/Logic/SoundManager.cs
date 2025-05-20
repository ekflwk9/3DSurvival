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
                Service.Log($"{sounds[i].name}��� SoundCode���� �߰� ���� ����");
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
        else Service.Log("\"EffectSound\"�� �̹� SoundManager�� �߰��Ǿ� ����");
    }

    public void Add(MusicSound _musicSource)
    {
        if (music == null) music = _musicSource;
        else Service.Log("\"MusicSound\"�� �̹� SoundManager�� �߰��Ǿ� ����");
    }

    public void SetVolume(float _volume)
    {
        volume = _volume;
        effect.SetVolume();
        music.SetVolume();
        solidSound?.Invoke();
    }

    /// <summary>
    /// Sound���ϰ� SoundManager/SoundCode�� �߰��� ��쿡�� ȣ�� ������
    /// </summary>
    /// <param name="_sound"></param>
    public void OnEffect(SoundCode _sound)
    {
        if (_sound == SoundCode.Stop) Service.Log("\'Stop\"�� OnEffect���� ����ϴ� ���� �ƴ�");
        else if (sound.ContainsKey(_sound)) effect.OnSound(sound[_sound]);
        else Service.Log($"{_sound.ToString()}�� ���� ���Ͽ� ���� ����");
    }

    /// <summary>
    /// Sound���ϰ� SoundManager/SoundCode�� �߰��� ��쿡�� ȣ�� ������
    /// </summary>
    /// <param name="_sound"></param>
    public void OnMusic(SoundCode _sound)
    {
        if (_sound == SoundCode.Stop) music.Stop();
        else if (sound.ContainsKey(_sound)) music.OnSound(sound[_sound]);
        else Service.Log($"{_sound.ToString()}�� ���� ���Ͽ� ���� ����");
    }
}
