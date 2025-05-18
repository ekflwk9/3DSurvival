using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiControler : MonoBehaviour, IAwake
{
    private void Awake() => GameManager.startManager.Add(this);

    public void OnAwake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
