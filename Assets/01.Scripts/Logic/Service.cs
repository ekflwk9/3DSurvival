using UnityEngine;

public delegate void Void();
public interface ILoad { public void OnLoad(); }
public interface IAwake { public void OnAwake(); }
public interface IStart { public void OnStart(); }

public class Service
{
    /// <summary>
    /// ������ ���� �α�
    /// </summary>
    /// <param name="_info"></param>
#if UNITY_EDITOR
    public static void Log(string _info) => Debug.Log(_info); 
#endif
}
