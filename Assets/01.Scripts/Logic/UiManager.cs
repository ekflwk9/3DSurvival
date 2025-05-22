using System.Collections.Generic;

public enum UiCode
{
    Menu = 0,
    Health = 1,
    ItemInfo = 2,
    Inventory = 3,
}

public class UiManager
{
    private Dictionary<UiCode, IUpdateUi> update = new Dictionary<UiCode, IUpdateUi>();
    private Dictionary<UiCode, IActiveUi> active = new Dictionary<UiCode, IActiveUi>();
    private Dictionary<UiCode, IGetIntegerUi> integer = new Dictionary<UiCode, IGetIntegerUi>();

    public void Add<T>(UiCode _uiCode, T _uiComponent) where T : class
    {
        if (_uiComponent is IUpdateUi updateUi)
        {
            if (!update.ContainsKey(_uiCode)) update.Add(_uiCode, updateUi);
            else Service.Log($"{_uiCode}라는 키로 이미 \"UpdateUi\"에 추가된 상태");
        }

        if (_uiComponent is IActiveUi activeUi)
        {
            if (!active.ContainsKey(_uiCode)) active.Add(_uiCode, activeUi);
            else Service.Log($"{_uiCode}라는 키로 이미 \"ActiveUi\"에 추가된 상태");
        }

        if(_uiComponent is IGetIntegerUi integerUi)
        {
            if (!integer.ContainsKey(_uiCode)) integer.Add(_uiCode, integerUi);
            else Service.Log($"{_uiCode}라는 키로 이미 \"IntegerUi\"에 추가된 상태");
        }
    }

    public void ActiveUi(UiCode _uiCode)
    {
        if (active.ContainsKey(_uiCode)) active[_uiCode].OnActive();
        else Service.Log($"{_uiCode}라는 키의 \"ActiveUi\"는 추가되지 않은 상태");
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

    /// <summary>
    /// 특정 Ui의 값을 조정할 경우 호출
    /// </summary>
    /// <param name="_uiCode"></param>
    /// <param name="_value"></param>
    public void SetIntegerUi(UiCode _uiCode, int _value)
    {
        if (integer.ContainsKey(_uiCode)) integer[_uiCode].OnGetIntegerUi(_value);
        else Service.Log($"{_uiCode}라는 키의 \"StateUi\"는 추가되지 않은 상태");
    }
}