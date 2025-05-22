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
                Service.Log($"{slot[i].name}���� \"Slot\"������Ʈ�� �������� ����");
            }
        }

        GameManager.ui.Add(UiCode.Inventory, this);
        GameManager.Add(this);

        this.gameObject.SetActive(false);
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
        var active = this.gameObject.activeSelf;

        this.gameObject.SetActive(!active);
        GameManager.stopGame = !active;

        Cursor.lockState = active ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !active;
    }
}
