using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum UiCode
{
    Menu = 0,
    Health = 1,
}

public class UiValue<T> where T : IShowUi, IHideUi, IStateUi
{
    private Dictionary<UiCode, T> uiValue;

    public void Add(UiCode _uiCode, T _uiComponent)
    {

    }

    public void Call(UiCode _uiCode)
    {

    }
}

public class UiManager : MonoBehaviour
{
    private Dictionary<UiCode, IShowUi> show = new Dictionary<UiCode, IShowUi>();
    private Dictionary<UiCode, IHideUi> hide = new Dictionary<UiCode, IHideUi>();
    private Dictionary<UiCode, IStateUi> state = new Dictionary<UiCode, IStateUi>();

    public void Add<T>(UiCode _uiCode, T _ui)
    {
        if(typeof(T) == typeof(IShowUi))
        {

        }
    }

    public void Add(UiCode _uiCode, IShowUi _showUi)
    {
        if (!show.ContainsKey(_uiCode)) show.Add(_uiCode, _showUi);
        else Service.Log($"{_uiCode}로 이미 추가된 IShowUi가 존재함");
    }

    public void Add(UiCode _uiCode, IHideUi _hideUi)
    {
        if (!hide.ContainsKey(_uiCode)) hide.Add(_uiCode, _hideUi);
        else Service.Log($"{_uiCode}로 이미 추가된 IHideUi가 존재함");
    }

    public void Add(UiCode _uiCode, IStateUi _stateUi)
    {
        if (!state.ContainsKey(_uiCode)) state.Add(_uiCode, _stateUi);
        else Service.Log($"{_uiCode}로 이미 추가된 IStateUi가 존재함");
    }


}
