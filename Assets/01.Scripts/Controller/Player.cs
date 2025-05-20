using UnityEngine;

public class Player : MonoBehaviour, ILoad, IHit
{
    private PlayerAction action;
    private PlayerController controller;
    public int health { get; private set; } = 100;
    public bool isMove { get => controller.isMove; }

    private void Awake() => GameManager.lifeCycle.Add(this);

    public void OnLoad()
    {
        //action = GetComponent<PlayerAction>();
        controller = GetComponent<PlayerController>();

        GameManager.Add(this);
        DontDestroyOnLoad(this.gameObject);
    }

    public void OnHit(int _dmg)
    {
        health -= _dmg;
        GameManager.cam.Action("HitShake");
        GameManager.ui.UpdateUi(UiCode.Health);
        //GameManager.sound.OnEffect(SoundCode.PlayerHit);
    }
}