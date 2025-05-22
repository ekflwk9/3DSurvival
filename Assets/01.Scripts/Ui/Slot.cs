using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour,
IAwake, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private int id;
    private int count;

    private Image icon;
    private TMP_Text itemNumber;

    private void Awake() => GameManager.lifeCycle.Add(this);

    public void OnAwake()
    {
        icon = this.transform.Find("Icon").GetComponent<Image>();
        itemNumber = this.transform.Find("Number").GetComponent<TMP_Text>();

        itemNumber.text = "";
        icon.color = Color.clear;
    }

    public bool GetItem(int _id)
    {
        if (id == 0)
        {
            id = _id;
            icon.color = Color.white;
            icon.sprite = GameManager.item.type[id].Sprite();
        }

        else if (id == _id)
        {
            count++;
            itemNumber.text = count.ToString();
        }

        else
        {
            return false;
        }

        return true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (id != 0)
        {
            GameManager.ui.ActiveUi(UiCode.ItemInfo);
            GameManager.ui.SetIntegerUi(UiCode.ItemInfo, id);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (id != 0) GameManager.ui.ActiveUi(UiCode.ItemInfo);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right && id != 0)
        {
            count--;

            if (count > -1)
            {
                itemNumber.text = count.ToString();
            }

            else
            {
                id = 0;
                count = 0;
                itemNumber.text = "";
                icon.color = Color.clear;
                GameManager.ui.ActiveUi(UiCode.ItemInfo);
            }
        }
    }
}
