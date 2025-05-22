using System;
using Unity.VisualScripting;
using UnityEngine;

public class PotionItem : MonoBehaviour, IStart, IInteraction, ITouch
{
    private ItemCode type;

    private void Awake() => GameManager.lifeCycle.Add(this);

    public void OnStart()
    {
        if (Enum.TryParse<ItemCode>(this.name, out var itemType)) type = itemType;
        else  Service.Log("�ش� ������ �̸��� \"ItemCode\"�� �߰��� �� �� ����");  
    }

    public bool OnInteraction()
    {
        this.gameObject.SetActive(false);
        GameManager.ui.ActiveUi(UiCode.CrossHair);
        GameManager.ui.SetIntegerUi(UiCode.Inventory, (int)type);

        return false;
    }

    public void OnItem()
    {
        GameManager.player.Heal(5);
    }

    public void OnTouch()
    {
        GameManager.ui.SetIntegerUi(UiCode.Touch, (int)type);
    }
}
