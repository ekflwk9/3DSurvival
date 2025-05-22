using System;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeItem : MonoBehaviour, IStart, IInteraction
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
        return false;
    }

    public void OnItem()
    {
        GameManager.player.Heal(5);
    }
}
