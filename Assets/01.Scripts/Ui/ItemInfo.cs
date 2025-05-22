using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour, ILoad, IActiveUi, IGetIntegerUi
{
    private RectTransform pos;
    private TMP_Text info;
    private TMP_Text itemName;

    private void Awake() => GameManager.lifeCycle.Add(this);

    public void OnLoad()
    {
        pos = GetComponent<RectTransform>();
        info = transform.Find("InfoText").GetComponent<TMP_Text>();
        itemName = transform.Find("Name").GetComponent<TMP_Text>();

        GameManager.ui.Add(UiCode.ItemInfo, this);
        this.gameObject.SetActive(false);
    }

    public void OnActive()
    {
        if (!this.gameObject.activeSelf)
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.anchoredPosition = mousePos;
            this.gameObject.SetActive(true);
        }

        else
        {
            this.gameObject.SetActive(false);
        }
    }

    public void OnGetIntegerUi(int _value)
    {
        var item = GameManager.item.type[_value];

        info.text = item.Info();
        itemName.text = item.Name();
    }
}