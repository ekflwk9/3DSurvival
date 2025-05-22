using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : MonoBehaviour, ILoad
{
    private void Awake() => GameManager.lifeCycle.Add(this);

    public void OnLoad()
    {
        GameManager.sound.Load();
        GameManager.item.Load();
    }
}
