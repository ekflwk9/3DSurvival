using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartComponent : MonoBehaviour
{
    private void Start() => GameManager.startManager.OnEvent();
}
