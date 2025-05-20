using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager
{
    public static bool stopGame;
    public static Fade fade { get; private set; }
    public static Player player { get; private set; }
    public static PlayCamera cam { get; private set; }

    public static readonly UiManager ui = new UiManager();

    public static readonly LifeCycle lifeCycle = new LifeCycle();

    public static readonly SoundManager sound = new SoundManager();

    public static readonly TriggerManager trigger = new TriggerManager();

    public static void ChangeScene(string _sceneName)
    {
        sound.Clear();
        lifeCycle.OnEndEvent();
        player.transform.position = Vector3.zero;
        SceneManager.LoadScene(_sceneName);
    }

    public static void Add(PlayCamera _camComponent)
    {
        if (cam == null) cam = _camComponent;
        else Service.Log("cam�� �̹� �Ŵ����� �߰��� ����");
    }

    public static void Add(Player _playerComponent)
    {
        if (player == null) player = _playerComponent;
        else Service.Log("Player�� �̹� �Ŵ����� �߰��� ����");
    }

    public static void Add(Fade _fadeComponent)
    {
        if (fade == null) fade = _fadeComponent;
        else Service.Log("FadeComponent�� �̹� �Ŵ����� �߰��� ����");
    }
}