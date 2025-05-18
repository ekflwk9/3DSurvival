using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    public static bool stopGame;
    public static Player player { get; private set; }
    public static CamController cam { get; private set; }

    public static readonly StartManager startManager = new StartManager();

    public static void Add(CamController _camComponent)
    {
        if (cam == null) cam = _camComponent;
        else Debug.Log("cam�� �̹� �Ŵ����� �߰��� ����");
    }

    public static void Add(Player _playerComponent)
    {
        if (player == null) player = _playerComponent;
        else Debug.Log("Player�� �̹� �Ŵ����� �߰��� ����");
    }
}