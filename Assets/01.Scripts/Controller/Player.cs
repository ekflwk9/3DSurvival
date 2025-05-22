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

        if (GameManager.player == null)
        {
            GameManager.Add(this);
            DontDestroyOnLoad(this.gameObject);
        }

        else
        {
            Destroy(this.gameObject);
        }
    }

    public void OnHit(int _dmg)
    {
        health -= _dmg;
        GameManager.cam.Action("HitShake");
        GameManager.ui.UpdateUi(UiCode.Health);
        //GameManager.sound.OnEffect(SoundCode.PlayerHit);
    }

    public void Heal(int _value)
    {
        if (health < 100)
        {
            health += _value;
            GameManager.ui.UpdateUi(UiCode.Health);
        }
    }
}