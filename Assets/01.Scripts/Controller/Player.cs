using UnityEngine;

public class Player : MonoBehaviour, ILoad
{
    private PlayerAction action;
    private PlayerController controller;

    public bool isMove { get => controller.isMove; }

    private void Awake() => GameManager.startManager.Add(this);

    public void OnLoad()
    {
        //action = GetComponent<PlayerAction>();
        controller = GetComponent<PlayerController>();

        GameManager.Add(this);
        DontDestroyOnLoad(this.gameObject);
    }
}
