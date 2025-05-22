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
        else  Service.Log("해당 아이템 이름은 \"ItemCode\"에 추가가 안 된 상태");  
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
