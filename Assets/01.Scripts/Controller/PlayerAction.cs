using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour, ILoad
{
    private Animator anim;

    private void Awake() => GameManager.startManager.Add(this);

    public void OnLoad()
    {
        anim = GetComponent<Animator>();
    }

    
}
