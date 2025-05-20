using System;
using System.Collections.Generic;
using UnityEngine;

public enum UiCode
{
    Menu = 0,
    Health = 1,
}

public class UiManager
{
    private Dictionary<UiCode, IShowUi> show = new Dictionary<UiCode, IShowUi>();
    private Dictionary<UiCode, IHideUi> hide = new Dictionary<UiCode, IHideUi>();
    private Dictionary<UiCode, IUpdateUi> update = new Dictionary<UiCode, IUpdateUi>();

    public void Add<T>(UiCode _uiCode, T _uiComponent) where T : class
    {
        if(_uiComponent is IShowUi showUi)
        {
            if (!show.ContainsKey(_uiCode)) show.Add(_uiCode, showUi);
            else Service.Log($"{_uiCode}��� Ű�� �̹� \"ShowUi\"�� �߰��� ����");
        }

        if (_uiComponent is IHideUi hideUi)
        {
            if (!hide.ContainsKey(_uiCode)) hide.Add(_uiCode, hideUi);
            else Service.Log($"{_uiCode}��� Ű�� �̹� \"HideUi\"�� �߰��� ����");
        }

        if (_uiComponent is IUpdateUi updateUi)
        {
            if (!update.ContainsKey(_uiCode)) update.Add(_uiCode, updateUi);
            else Service.Log($"{_uiCode}��� Ű�� �̹� \"UpdateUi\"�� �߰��� ����");
        }
    }

    /// <summary>
    /// Ȱ��ȭ �ϰ� ���� UI ȣ�� (���ٸ� UiManager/UiCode�� �߰�)
    /// </summary>
    /// <param name="_uiCode"></param>
    public void Show(UiCode _uiCode)
    {
        if (show.ContainsKey(_uiCode)) show[_uiCode].OnShow();
        else Service.Log($"{_uiCode}��� Ű�� \"ShowUi\"�� �߰����� ���� ����");
    }

    /// <summary>
    /// ����� ���� UI ȣ�� (���ٸ� UiManager/UiCode�� �߰�)
    /// </summary>
    /// <param name="_uiCode"></param>
    public void Hide(UiCode _uiCode)
    {
        if (hide.ContainsKey(_uiCode)) hide[_uiCode].OnHide();
        else Service.Log($"{_uiCode}��� Ű�� \"HideUi\"�� �߰����� ���� ����");
    }

    /// <summary>
    /// ���¸� ������Ʈ�ϰ� ���� Ui�� ȣ�� (���ٸ� UiManager/UiCode�� �߰�)
    /// </summary>
    /// <param name="_uiCode"></param>
    public void UpdateUi(UiCode _uiCode)
    {
        if (update.ContainsKey(_uiCode)) update[_uiCode].OnUpdate();
        else Service.Log($"{_uiCode}��� Ű�� \"StateUi\"�� �߰����� ���� ����");
    }
}