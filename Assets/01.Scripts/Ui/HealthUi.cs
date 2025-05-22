using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUi : MonoBehaviour, ILoad, IUpdateUi, IActiveUi
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
        slider.fillAmount = GameManager.player.health * 0.01f;
    }

    public void OnActive()
    {
        if(this.gameObject.activeSelf) this.gameObject.SetActive(false);
        else this.gameObject.SetActive(true);
    }
}
