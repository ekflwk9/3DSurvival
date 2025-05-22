using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiControler : MonoBehaviour, IAwake
{
    private void Awake() => GameManager.lifeCycle.Add(this);

    public void OnAwake()
    {  
        DontDestroyOnLoad(this.gameObject);
    }

    /// <summary>
    /// InputSystem에서 호출
    /// </summary>
    public void OnMenu()
    {

    }

    /// <summary>
    /// InputSystem에서 호출
    /// </summary>
    public void OnInventory()
    {
        GameManager.ui.ActiveUi(UiCode.Inventory);
    }
}
