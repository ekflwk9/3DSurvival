using Unity.VisualScripting;
using UnityEngine;

public class MusicSound : MonoBehaviour, IAwake
{
    private AudioSource source;

    private void Awake() => GameManager.lifeCycle.Add(this);

    public void OnAwake()
    {
        source = this.AddComponent<AudioSource>();
        source.playOnAwake = false;
        source.volume = 0.5f;

        GameManager.sound.Add(this);
    }

    public void SetVolume()
    {
        source.volume = GameManager.sound.volume;
    }

    public void OnSound(AudioClip _sound)
    {
        source.clip = _sound;
        source.Play();
    }

    public void Stop()
    {
        source.Stop();
    }
}
