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
            else Service.Log($"{unityObject.name}�̶�� ������Ʈ�� �̹� \"Hit\"�� �߰��� ����");
        }

        else
        {
            Service.Log("MonoBehaviour�� ���� ��ü�� �߰��� �� ����");
        }
    }

    public void Add(IInteraction _interactionScript)
    {
        if (_interactionScript is MonoBehaviour unityObject)
        {
            if (!interaction.ContainsKey(unityObject.name)) interaction.Add(unityObject.name, _interactionScript);
            else Service.Log($"{unityObject.name}�̶�� ������Ʈ�� �̹� \"Interaction\"�� �߰��� ����");
        }

        else
        {
            Service.Log("MonoBehaviour�� ���� ��ü�� �߰��� �� ����");
        }
    }

    public void Remove(IHit _hitScript)
    {
        if (_hitScript is MonoBehaviour unityObject)
        {
            if (hit.ContainsKey(unityObject.name)) hit.Remove(unityObject.name);
            else Service.Log($"{unityObject.name}�̶�� ������Ʈ�� \"Hit\"�� �����ϴ�.");
        }

        else
        {
            Service.Log("MonoBehaviour�� ���� ��ü�� �߰��� �� ����");
        }
    }

    public void Remove(IInteraction _interactionScript)
    {
        if (_interactionScript is MonoBehaviour unityObject)
        {
            if (interaction.ContainsKey(unityObject.name)) interaction.Remove(unityObject.name);
            else Service.Log($"{unityObject.name}�̶�� ������Ʈ�� \"Interaction\"�� �����ϴ�.");
        }

        else
        {
            Service.Log("MonoBehaviour�� ���� ��ü�� �߰��� �� ����");
        }
    }
}
