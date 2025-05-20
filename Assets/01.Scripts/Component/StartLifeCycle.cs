using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLifeCycle : MonoBehaviour
{
    private void Start() => GameManager.lifeCycle.OnEvent();
}