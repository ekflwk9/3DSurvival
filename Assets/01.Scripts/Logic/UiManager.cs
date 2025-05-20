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
            else Service.Log($"{_uiCode}라는 키로 이미 \"ShowUi\"에 추가된 상태");
        }

        if (_uiComponent is IHideUi hideUi)
        {
            if (!hide.ContainsKey(_uiCode)) hide.Add(_uiCode, hideUi);
            else Service.Log($"{_uiCode}라는 키로 이미 \"HideUi\"에 추가된 상태");
        }

        if (_uiComponent is IUpdateUi updateUi)
        {
            if (!update.ContainsKey(_uiCode)) update.Add(_uiCode, updateUi);
            else Service.Log($"{_uiCode}라는 키로 이미 \"UpdateUi\"에 추가된 상태");
        }
    }

    /// <summary>
    /// 활성화 하고 싶은 UI 호출 (없다면 UiManager/UiCode에 추가)
    /// </summary>
    /// <param name="_uiCode"></param>
    public void Show(UiCode _uiCode)
    {
        if (show.ContainsKey(_uiCode)) show[_uiCode].OnShow();
        else Service.Log($"{_uiCode}라는 키의 \"ShowUi\"는 추가되지 않은 상태");
    }

    /// <summary>
    /// 숨기고 싶은 UI 호출 (없다면 UiManager/UiCode에 추가)
    /// </summary>
    /// <param name="_uiCode"></param>
    public void Hide(UiCode _uiCode)
    {
        if (hide.ContainsKey(_uiCode)) hide[_uiCode].OnHide();
        else Service.Log($"{_uiCode}라는 키의 \"HideUi\"는 추가되지 않은 상태");
    }

    /// <summary>
    /// 상태를 업데이트하고 싶은 Ui를 호출 (없다면 UiManager/UiCode에 추가)
    /// </summary>
    /// <param name="_uiCode"></param>
    public void UpdateUi(UiCode _uiCode)
    {
        if (update.ContainsKey(_uiCode)) update[_uiCode].OnUpdate();
        else Service.Log($"{_uiCode}라는 키의 \"StateUi\"는 추가되지 않은 상태");
    }
}