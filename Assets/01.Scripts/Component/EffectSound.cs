using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EffectSound : MonoBehaviour, IAwake
{
    private AudioSource[] source;
    private int playCount;

    private void Awake() => GameManager.lifeCycle.Add(this);

    public void OnAwake()
    {
        source = new AudioSource[10];

        for(int i  = 0; i < source.Length; i++)
        {
            source[i] = this.AddComponent<AudioSource>();

            source[i].playOnAwake = false;
            source[i].loop = false;
            source[i].volume = 0.5f;
        }

        GameManager.sound.Add(this);
    }

    public void SetVolume()
    {
        for (int i = 0; i < source.Length; i++)
        {
            source[i].volume = GameManager.sound.volume;
        }
    }

    public void OnSound(AudioClip _sound)
    {
        playCount ++;
        if(playCount >= source.Length) playCount = 0;

        source[playCount].clip = _sound;
        source[playCount].Play();
    }
}
