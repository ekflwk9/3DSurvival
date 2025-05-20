using UnityEngine;

public delegate void Void();

//LifeCycle
public interface ILoad { public void OnLoad(); }
public interface IAwake { public void OnAwake(); }
public interface IStart { public void OnStart(); }
public interface IEnd { public void OnEnd(); }
public interface ISolidSound { public void OnVolume(); }

//UI
public interface IShowUi { public void OnShow(); }
public interface IHideUi { public void OnHide(); }
public interface IUpdateUi { public void OnUpdate(); }

//Game
public interface IHit { public void OnHit(int _dmg); }
public interface IInteraction { public void OnInteraction(); }

public class Service
{
    public static readonly WaitForSeconds oneSecond= new WaitForSeconds(1);

    /// <summary>
    /// Resource���� / Ư�� ���Ͽ��� ã�� ���� �������� �ҷ���
    /// </summary>
    /// <param name="_fileName"></param>
    /// <returns></returns>
    public static GameObject FindSource(string _fileName, string _itemName)
    {
        var item = Resources.Load<GameObject>($"{_fileName}/{_itemName}");
        if (item == null) Service.Log($"{_fileName}/{_itemName}�� �������� ã�� �� ����");

        return item;
    }

    /// <summary>
    /// ������ ���� �α�
    /// </summary>
    /// <param name="_info"></param>
    public static void Log(string _info)
    {
#if UNITY_EDITOR
        Debug.Log(_info);
#endif
    }
}
