using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Touch : MonoBehaviour, ILoad, IGetIntegerUi
{
    private TMP_Text touchInfo;

    private void Awake() => GameManager.lifeCycle.Add(this);

    public void OnLoad()
    {
        if (TryGetComponent<TMP_Text>(out var target)) touchInfo = target;
        else Service.Log($"{this.name}에 \"TouchInfo TMP Text가 없음\"");

        touchInfo.text = "";
        GameManager.ui.Add(UiCode.Touch, this);
    }

    public void OnGetIntegerUi(int _value)
    {
        if(_value == 0)
        {
            touchInfo.text = "";
        }

        else
        {
            touchInfo.text = GameManager.item.type[_value].Name();
        }
    }
}
