using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUi : MonoBehaviour, ILoad, IStateUi
{
    private Image slider;

    private void Awake() => GameManager.startManager.Add(this);

    public void OnLoad()
    {
        slider = GetComponent<Image>(); 
        slider.fillAmount = 1;
    }

    public void OnState()
    {
        //var fillAmount = _value * 0.01f;
        //slider.fillAmount -= fillAmount;
    }
}
