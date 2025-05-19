using UnityEngine;

public delegate void Void();

//LifeCycle
public interface ILoad { public void OnLoad(); }
public interface IAwake { public void OnAwake(); }
public interface IStart { public void OnStart(); }

//UI
public interface IShowUi{ public void OnShow(); }
public interface IHideUi{ public void OnHide(); }
public interface IUpdateUi{ public void OnUpdate(); }

//Game
public interface IHit{ public void OnHit(); }

public class Service
{
    /// <summary>
    /// 에디터 전용 로그
    /// </summary>
    /// <param name="_info"></param>
    public static void Log(string _info)
    {
#if UNITY_EDITOR
        Debug.Log(_info);
#endif
    }
}
