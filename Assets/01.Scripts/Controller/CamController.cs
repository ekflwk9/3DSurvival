using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour, ILoad
{
    private void Awake() => GameManager.startManager.Add(this);

    public void OnLoad()
    {

    }

    private void Update()
    {
        
    }
}
