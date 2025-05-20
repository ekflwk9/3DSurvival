using UnityEngine;

public class PlayerAction : MonoBehaviour, ILoad
{
    private Animator anim;

    private void Awake() => GameManager.lifeCycle.Add(this);

    public void OnLoad()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!GameManager.stopGame)
        {
            Move();
        }
    }

    private void Move()
    {
        anim.SetBool("Move", GameManager.player.isMove);
    }
}
