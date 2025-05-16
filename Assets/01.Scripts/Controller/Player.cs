using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ILoad
{
    private PlayerAction action;
    private PlayerController controller;

    private void Awake() => GameManager.startManager.Add(this);

    public void OnLoad()
    {
        action = GetComponent<PlayerAction>();
        controller = GetComponent<PlayerController>();

        GameManager.Add(this);
    }
}
