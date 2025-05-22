using UnityEngine;

public class Inventory : MonoBehaviour, IAwake, IActiveUi, IGetIntegerUi
{
    private Slot[] slot;

    private void Awake() => GameManager.lifeCycle.Add(this);

    public void OnAwake()
    {
        var childCount = this.transform.childCount;
        slot = new Slot[childCount];

        for (int i = 0; i < childCount; i++)
        {
            if (this.transform.GetChild(i).TryGetComponent<Slot>(out var target))
            {
                slot[i] = target;
            }

            else
            {
                Service.Log($"{slot[i].name}에는 \"Slot\"컴포넌트가 존재하지 않음");
            }
        }

        this.gameObject.SetActive(false);
        GameManager.ui.Add(UiCode.Inventory, this);
        GameManager.Add(this);
    }

    public void OnGetIntegerUi(int _itemId)
    {
        for (int i = 0; i < slot.Length; i++)
        {
            if (slot[i].GetItem(_itemId)) break;
        }
    }

    public void OnActive()
    {
        if (this.gameObject.activeSelf) this.gameObject.SetActive(false);
        else this.gameObject.SetActive(true);
    }
}
