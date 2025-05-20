using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager
{
    public Dictionary<string, IHit> hit = new Dictionary<string, IHit>();
    public Dictionary<string, IInteraction> interaction = new Dictionary<string, IInteraction>();

    public void Add(IHit _hitScript)
    {
        if (_hitScript is MonoBehaviour unityObject) 
        {
            if (!hit.ContainsKey(unityObject.name)) hit.Add(unityObject.name, _hitScript);
            else Service.Log($"{unityObject.name}이라는 오브젝트는 이미 \"Hit\"가 추가된 상태");
        }

        else
        {
            Service.Log("MonoBehaviour가 없는 객체는 추가할 수 없음");
        }
    }

    public void Add(IInteraction _interactionScript)
    {
        if (_interactionScript is MonoBehaviour unityObject)
        {
            if (!interaction.ContainsKey(unityObject.name)) interaction.Add(unityObject.name, _interactionScript);
            else Service.Log($"{unityObject.name}이라는 오브젝트는 이미 \"Interaction\"에 추가된 상태");
        }

        else
        {
            Service.Log("MonoBehaviour가 없는 객체는 추가할 수 없음");
        }
    }

    public void Remove(IHit _hitScript)
    {
        if (_hitScript is MonoBehaviour unityObject)
        {
            if (hit.ContainsKey(unityObject.name)) hit.Remove(unityObject.name);
            else Service.Log($"{unityObject.name}이라는 오브젝트는 \"Hit\"에 없습니다.");
        }

        else
        {
            Service.Log("MonoBehaviour가 없는 객체는 추가할 수 없음");
        }
    }

    public void Remove(IInteraction _interactionScript)
    {
        if (_interactionScript is MonoBehaviour unityObject)
        {
            if (interaction.ContainsKey(unityObject.name)) interaction.Remove(unityObject.name);
            else Service.Log($"{unityObject.name}이라는 오브젝트는 \"Interaction\"에 없습니다.");
        }

        else
        {
            Service.Log("MonoBehaviour가 없는 객체는 추가할 수 없음");
        }
    }
}
