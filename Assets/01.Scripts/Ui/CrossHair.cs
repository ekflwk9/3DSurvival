using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour, ILoad, IActiveUi
{
    private void Awake() => GameManager.lifeCycle.Add(this);

    public void OnLoad() => GameManager.ui.Add(UiCode.CrossHair, this);

    public void OnActive()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}