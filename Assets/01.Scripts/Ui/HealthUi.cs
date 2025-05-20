using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUi : MonoBehaviour, ILoad, IUpdateUi, IShowUi, IHideUi
{
    private Image slider;

    private void Awake() => GameManager.lifeCycle.Add(this);

    public void OnLoad()
    {
        slider = GetComponent<Image>(); 
        slider.fillAmount = 1;

        GameManager.ui.Add(UiCode.Health, this);
    }

    public void OnUpdate()
    {
        var fillAmount = GameManager.player.health * 0.01f;
        slider.fillAmount -= fillAmount;
    }

    public void OnShow() => this.gameObject.SetActive(true);

    public void OnHide() => this.gameObject.SetActive(false);
}
