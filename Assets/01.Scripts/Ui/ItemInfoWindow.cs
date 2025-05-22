using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;

public class ItemInfoWindow : MonoBehaviour, ILoad, IActiveUi, IGetIntegerUi
{
    private Sprite icon;
    private TMP_Text info;
    private TMP_Text itemName;

    private void Awake() => GameManager.lifeCycle.Add(this);

    public void OnLoad()
    {
        info = transform.Find("InfoText").GetComponent<TMP_Text>();
        itemName = transform.Find("Name").GetComponent<TMP_Text>();
        GameManager.ui.Add(UiCode.ItemInfo, this);
    }

    public void OnActive()
    {
        if (this.gameObject.activeSelf) this.gameObject.SetActive(false);
        else this.gameObject.SetActive(true);
    }

    public void OnGetIntegerUi(int _value)
    {
        var item = GameManager.item.item[_value];

        icon = item.Sprite();
        info.text = item.Info();
        itemName.text = item.name;
    }
}