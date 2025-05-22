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
            else Service.Log($"{_uiCode}��� Ű�� �̹� \"UpdateUi\"�� �߰��� ����");
        }

        if (_uiComponent is IActiveUi activeUi)
        {
            if (!active.ContainsKey(_uiCode)) active.Add(_uiCode, activeUi);
            else Service.Log($"{_uiCode}��� Ű�� �̹� \"ActiveUi\"�� �߰��� ����");
        }

        if(_uiComponent is IGetIntegerUi integerUi)
        {
            if (!integer.ContainsKey(_uiCode)) integer.Add(_uiCode, integerUi);
            else Service.Log($"{_uiCode}��� Ű�� �̹� \"IntegerUi\"�� �߰��� ����");
        }
    }

    public void ActiveUi(UiCode _uiCode)
    {
        if (active.ContainsKey(_uiCode)) active[_uiCode].OnActive();
        else Service.Log($"{_uiCode}��� Ű�� \"ActiveUi\"�� �߰����� ���� ����");
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

    /// <summary>
    /// Ư�� Ui�� ���� ������ ��� ȣ��
    /// </summary>
    /// <param name="_uiCode"></param>
    /// <param name="_value"></param>
    public void SetIntegerUi(UiCode _uiCode, int _value)
    {
        if (integer.ContainsKey(_uiCode)) integer[_uiCode].OnGetIntegerUi(_value);
        else Service.Log($"{_uiCode}��� Ű�� \"StateUi\"�� �߰����� ���� ����");
    }
}