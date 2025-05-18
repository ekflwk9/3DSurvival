using UnityEngine;

public delegate void Void();
public interface ILoad { public void OnLoad(); }
public interface IAwake { public void OnAwake(); }
public interface IStart { public void OnStart(); }

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
