using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager : MonoBehaviour, ILoad
{
    private void Awake() => GameManager.startManager.Add(this);

    public void OnLoad()
    {

    }
}
